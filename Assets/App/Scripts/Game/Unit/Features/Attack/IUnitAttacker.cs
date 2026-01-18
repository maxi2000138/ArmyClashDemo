using App.Scripts.Game.Unit;

namespace App.Scripts.Game.Unit.Features.Attack
{
  public interface IUnitAttacker
  {
    bool TryAttack(GameUnit unit);
  }
}