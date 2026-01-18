namespace App.Scripts.Game.Unit.Features.FindTarget
{
  public interface IUnitTargetFinder
  {
    bool TryFindTarget(GameUnit unit, out GameUnit target);
  }
}