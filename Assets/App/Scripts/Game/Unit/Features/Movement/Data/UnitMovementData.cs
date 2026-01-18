using UnityEngine;

namespace App.Scripts.Game.Unit.Features.Movement.Data
{
  public class UnitMovementData
  {
    public float CurrentSpeed { get; set; }
    public Vector3 Direction { get; set; }

    public UnitMovementData()
    {
      CurrentSpeed = 0f;
      Direction = Vector3.zero;
    }
  }
}