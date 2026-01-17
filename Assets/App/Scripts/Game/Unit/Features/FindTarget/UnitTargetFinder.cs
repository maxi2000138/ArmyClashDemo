using System.Collections.Generic;
using System.Linq;
using App.Scripts.Utils;
using UnityEngine;

namespace App.Scripts.Game.Unit.Features.FindTarget
{
  public class UnitTargetFinder
  {
    private readonly SimulationModel _simulationModel;

    public UnitTargetFinder(SimulationModel simulationModel)
    {
      _simulationModel = simulationModel;
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
      if (_simulationModel.FirstTeamUnits.Contains(unit))
        return _simulationModel.SecondTeamUnits;

      return _simulationModel.FirstTeamUnits;
    }
  }
}