using UnityEngine;

namespace App.Scripts.Game.Unit.Features.Attack
{
  public class AttackData
  {
    private float _lastAttackTime;

    public bool IsCooldownReady(float cooldown)
    {
      if (_lastAttackTime == 0)
        return true;

      return Time.time - _lastAttackTime >= cooldown;
    }

    public void UpdateCooldown()
    {
      _lastAttackTime = Time.time;
    }
  }
}