using System.Collections.Generic;
using App.Scripts.Infrastructure.StaticData;
using UnityEngine;

namespace App.Scripts.Game.Unit.Features.Movement
{
  public class UnitMover : IUnitMover
  {
    private readonly GameModel _gameModel;
    private readonly IStaticDataService _staticData;
    private readonly Dictionary<GameUnit, float> _currentSpeeds = new Dictionary<GameUnit, float>();

    public UnitMover(GameModel gameModel, IStaticDataService staticData)
    {
      _gameModel = gameModel;
      _staticData = staticData;
    }

    public void MoveToTarget(GameUnit unit)
    {
      if (unit.Target == null || !unit.Target.IsAlive)
      {
        unit.CurrentDirection = Vector3.zero;
        if (_currentSpeeds.ContainsKey(unit))
          _currentSpeeds[unit] = Mathf.Lerp(_currentSpeeds[unit], 0f,
            _staticData.MovementConfig.RotationSmoothness * Time.deltaTime);
        return;
      }

      var currentPosition = unit.transform.position;
      var targetPosition = unit.Target.transform.position;
      var directionToTarget = targetPosition - currentPosition;
      var distance = directionToTarget.magnitude;

      var requiredDistance = _staticData.AttackConfig.AttackRadius +
                             unit.View.CollisionRadius +
                             unit.Target.View.CollisionRadius;

      if (distance <= requiredDistance)
      {
        unit.CurrentDirection = Vector3.zero;
        if (_currentSpeeds.ContainsKey(unit))
          _currentSpeeds[unit] = Mathf.Lerp(_currentSpeeds[unit], 0f,
            _staticData.MovementConfig.RotationSmoothness * Time.deltaTime);
        return;
      }

      var seekDirection = directionToTarget.normalized;
      var separationDirection = CalculateSeparation(unit, currentPosition);

      var movementConfig = _staticData.MovementConfig;
      var desiredDirection = (seekDirection + separationDirection * movementConfig.AvoidanceStrength).normalized;

      var currentDirection = unit.CurrentDirection;
      if (currentDirection.magnitude < 0.01f)
        currentDirection = desiredDirection;
      else
        currentDirection = currentDirection.normalized;

      var smoothDirection = Vector3.Slerp(currentDirection, desiredDirection,
        movementConfig.RotationSmoothness * Time.deltaTime);

      if (!_currentSpeeds.TryGetValue(unit, out var currentSpeed))
        currentSpeed = 0f;

      var smoothSpeed = Mathf.Lerp(currentSpeed, unit.Characteristics.Speed,
        movementConfig.RotationSmoothness * Time.deltaTime);
      _currentSpeeds[unit] = smoothSpeed;

      unit.CurrentDirection = smoothDirection;
      unit.transform.position += smoothDirection * smoothSpeed * Time.deltaTime;
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

        if (distanceSquared > detectionRadiusSquared || distanceSquared < 0.001f)
          continue;

        var distance = Mathf.Sqrt(distanceSquared);
        separationForce += directionAway.normalized / distance;
      }

      return separationForce.normalized;
    }
  }
}