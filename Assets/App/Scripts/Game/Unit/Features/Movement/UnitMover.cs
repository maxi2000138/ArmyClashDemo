using App.Scripts.Game.Unit.Features.Movement.Configs;
using App.Scripts.Infrastructure.StaticData;
using App.Scripts.Utils;
using UnityEngine;

namespace App.Scripts.Game.Unit.Features.Movement
{
  public class UnitMover : IUnitMover
  {
    private readonly GameModel _gameModel;
    private readonly IStaticDataService _staticData;

    public UnitMover(GameModel gameModel, IStaticDataService staticData)
    {
      _gameModel = gameModel;
      _staticData = staticData;
    }

    public void MoveToTarget(GameUnit unit)
    {
      if (unit.Target == null || !unit.Target.IsAlive)
      {
        StopUnit(unit);
        return;
      }

      var directionToTarget = unit.Target.transform.position - unit.transform.position;
      if (directionToTarget.magnitude <= _staticData.AttackConfig.AttackRadius)
      {
        StopUnit(unit);
        return;
      }

      var separationDirection = CalculateSeparation(unit, unit.transform.position);
      var desiredDirection = CurrentDirection(unit, directionToTarget.normalized, separationDirection, _staticData.MovementConfig, out var currentDirection);
      var smoothDirection = SmoothDirection(unit, currentDirection, desiredDirection, _staticData.MovementConfig);

      var smoothSpeed = SmoothSpeed(unit, _staticData.MovementConfig);

      unit.transform.position += smoothDirection * (smoothSpeed * Time.deltaTime);
    }

    private Vector3 CurrentDirection(GameUnit unit, Vector3 seekDirection, Vector3 separationDirection, MovementConfig movementConfig, out Vector3 currentDirection)
    {
      var desiredDirection = (seekDirection + separationDirection * movementConfig.AvoidanceStrength).normalized;

      currentDirection = unit.MovementData.Direction;
      if (currentDirection.magnitude < 0.01f)
        currentDirection = desiredDirection;
      else
        currentDirection = currentDirection.normalized;
      return desiredDirection;
    }

    private Vector3 SmoothDirection(GameUnit unit, Vector3 currentDirection, Vector3 desiredDirection, MovementConfig movementConfig)
    {
      var smoothDirection = Vector3.Slerp(currentDirection, desiredDirection,
        movementConfig.RotationSmoothness * Time.deltaTime);
      unit.MovementData.Direction = smoothDirection;

      return smoothDirection;
    }

    private float SmoothSpeed(GameUnit unit, MovementConfig movementConfig)
    {
      var smoothSpeed = Mathf.Lerp(unit.MovementData.CurrentSpeed, unit.Characteristics.Speed,
        movementConfig.RotationSmoothness * Time.deltaTime);
      unit.MovementData.CurrentSpeed = smoothSpeed;

      return smoothSpeed;
    }

    private void StopUnit(GameUnit unit)
    {
      unit.MovementData.Direction = Vector3.zero;
      unit.MovementData.CurrentSpeed = Mathf.Lerp(unit.MovementData.CurrentSpeed, 0f,
        _staticData.MovementConfig.RotationSmoothness * Time.deltaTime);
    }

    private Vector3 CalculateSeparation(GameUnit unit, Vector3 currentPosition)
    {
      var separationForce = Vector3.zero;
      var detectionRadius = unit.View.CollisionRadius * _staticData.MovementConfig.DetectionRadiusMultiplier;
      var detectionRadiusSquared = detectionRadius * detectionRadius;

      foreach (var otherUnit in _gameModel.AllUnits)
      {
        if (otherUnit == unit || !otherUnit.IsAlive)
          continue;

        var directionAway = currentPosition - otherUnit.transform.position;
        var distanceSquared = directionAway.sqrMagnitude;

        if (distanceSquared > detectionRadiusSquared || distanceSquared < Mathematics.Epsilon)
          continue;

        var distance = Mathf.Sqrt(distanceSquared);
        separationForce += directionAway.normalized / distance;
      }

      return separationForce.normalized;
    }
  }
}