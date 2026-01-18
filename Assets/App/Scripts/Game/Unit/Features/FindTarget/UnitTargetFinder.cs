using System.Collections.Generic;
using System.Linq;
using App.Scripts.Utils;
using App.Scripts.Utils.Extensions;
using UnityEngine;

namespace App.Scripts.Game.Unit.Features.FindTarget
{
  public class UnitTargetFinder : IUnitTargetFinder
  {
    private readonly GameModel _gameModel;

    public UnitTargetFinder(GameModel gameModel)
    {
      _gameModel = gameModel;
    }

    public bool TryFindTarget(GameUnit unit, out GameUnit target)
    {
      var enemies = EnemiesFor(unit).ToList();

      if (enemies.Count > 0)
      {
        target = enemies.PickRandomOrDefault();
        return true;
      }

      target = null;
      return false;
    }

    private IReadOnlyList<GameUnit> EnemiesFor(GameUnit unit)
    {
      if (_gameModel.FirstTeamUnits.Contains(unit))
        return _gameModel.SecondTeamUnits;

      return _gameModel.FirstTeamUnits;
    }
  }
}