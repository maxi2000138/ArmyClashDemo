using App.Scripts.Infrastructure.StaticData;
using UnityEngine;

namespace App.Scripts.Game.Unit.Features.Attack
{
  public class UnitAttacker : IUnitAttacker
  {
    private readonly IStaticDataService _staticData;

    public UnitAttacker(IStaticDataService staticData)
    {
      _staticData = staticData;
    }

    public bool TryAttack(GameUnit unit)
    {
      if (unit.Target == null || !unit.Target.IsAlive)
        return false;

      if (!IsInAttackRange(unit, unit.Target))
        return false;

      if (!IsCooldownReady(unit))
        return false;

      PerformAttack(unit, unit.Target);
      UpdateCooldown(unit);
      return true;
    }

    private bool IsInAttackRange(GameUnit unit, GameUnit target)
    {
      var distance = Vector3.Distance(unit.transform.position, target.transform.position);
      var attackRadius = _staticData.AttackConfig.AttackRadius;
      var unitRadius = unit.View.CollisionRadius;
      var targetRadius = target.View.CollisionRadius;
      var requiredDistance = attackRadius + unitRadius + targetRadius;

      return distance <= requiredDistance;
    }

    private bool IsCooldownReady(GameUnit unit)
    {
      var cooldown = unit.Characteristics.AtkSpd;
      return unit.AttackData.IsCooldownReady(cooldown);
    }

    private void PerformAttack(GameUnit attacker, GameUnit target)
    {
      var damage = attacker.Characteristics.Atk;
      var newHealth = target.Health.Value - damage;
      target.Health.SetCurrentHealth(newHealth);
    }

    private void UpdateCooldown(GameUnit unit)
    {
      unit.AttackData.UpdateCooldown();
    }
  }
}