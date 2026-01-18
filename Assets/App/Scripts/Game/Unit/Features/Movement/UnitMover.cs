using System.Collections.Generic;
using System.Linq;
using App.Scripts.Infrastructure.StaticData;
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
      if (unit.Target == null)
        return;

      var direction = CalculateDirection(unit);
      unit.transform.position += direction * (_staticData.MovementConfig.MoveSpeed * Time.deltaTime);
    }

    private Vector3 CalculateDirection(GameUnit unit)
    {
      var targetDirection = DirectionToTarget(unit, unit.Target);
      var avoidanceDirection = CalculateAvoidance(unit);

      var finalDirection = (targetDirection + avoidanceDirection * _staticData.MovementConfig.AvoidanceStrength).normalized;
      return finalDirection;
    }

    private Vector3 DirectionToTarget(GameUnit unit, GameUnit target)
    {
      return (target.transform.position - unit.transform.position).normalized;
    }

    private Vector3 CalculateAvoidance(GameUnit unit)
    {
      var avoidanceVector = Vector3.zero;
      var unitRadius = unit.View.CollisionRadius;
      var nearbyUnits = GetNearbyUnits(unit, unitRadius);

      foreach (var nearbyUnit in nearbyUnits)
      {
        var distance = Vector3.Distance(unit.transform.position, nearbyUnit.transform.position);
        var nearbyUnitRadius = nearbyUnit.View.CollisionRadius;
        var minDistance = unitRadius + nearbyUnitRadius;

        var minCollisionDistance = _staticData.MovementConfig.MinCollisionDistance;
        if (distance < minDistance && distance > minCollisionDistance)
        {
          var directionFromNearby = (unit.transform.position - nearbyUnit.transform.position).normalized;
          var avoidanceWeightOffset = _staticData.MovementConfig.AvoidanceWeightOffset;
          var weight = 1.0f / (distance + avoidanceWeightOffset);
          avoidanceVector += directionFromNearby * weight;
        }
      }

      return avoidanceVector.normalized;
    }

    private IEnumerable<GameUnit> GetNearbyUnits(GameUnit unit, float unitRadius)
    {
      var detectionRadius = unitRadius * _staticData.MovementConfig.DetectionRadiusMultiplier;

      return _gameModel.AllUnits
        .Where(other => {
          if (other == unit)
            return false;

          var distance = Vector3.Distance(unit.transform.position, other.transform.position);
          var otherRadius = other.View.CollisionRadius;
          var maxDetectionDistance = detectionRadius + otherRadius;
          return distance <= maxDetectionDistance;
        });
    }
  }
}