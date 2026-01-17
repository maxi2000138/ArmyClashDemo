using UnityEngine;

namespace App.Scripts.Game.Unit.Features.Movement
{
  public class UnitMover
  {
    public void MoveToTarget(GameUnit unit)
    {
      unit.transform.position += Direction(unit, unit.Target) * Time.deltaTime;
    }
    
    private Vector3 Direction(GameUnit unit, GameUnit target) => (target.transform.position - unit.transform.position).normalized;
  }
}