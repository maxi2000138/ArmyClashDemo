using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Game.Unit.Features.Movement.Configs
{

  [CreateAssetMenu(fileName = nameof(MovementConfig), menuName = "Configs/" + nameof(MovementConfig), order = -1000)]
  public class MovementConfig : SerializedScriptableObject
  {
    public float DetectionRadiusMultiplier = 1.5f;
    public float AvoidanceStrength = 1.0f;
    public float MoveSpeed = 1.0f;
    public float MinCollisionDistance = 0.01f;
    public float AvoidanceWeightOffset = 0.1f;
  }
}