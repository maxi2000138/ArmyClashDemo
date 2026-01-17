using System;
using System.Collections.Generic;
using App.Scripts.Game.Unit;
using App.Scripts.Game.Unit.Stats;

namespace App.Scripts.Game
{
  public class SimulationModel
  {
    public IReadOnlyList<GameUnit> FirstTeamUnits => _firstTeamUnitsUnits;
    public IReadOnlyList<GameUnit> SecondTeamUnits => _secondTeamUnits;
    public IReadOnlyList<GameUnit> AllUnits => _allUnits;

    private readonly List<GameUnit> _firstTeamUnitsUnits = new List<GameUnit>();
    private readonly List<GameUnit> _secondTeamUnits = new List<GameUnit>();
    private readonly List<GameUnit> _allUnits = new List<GameUnit>();
    
    public void AddUnit(GameUnit unit)
    {
      _allUnits.Add(unit);
      
      if(unit.Team == UnitTeam.First)
        _firstTeamUnitsUnits.Add(unit);
      else
        _secondTeamUnits.Add(unit);
    }

    public void RemoveUnit(GameUnit unit)
    {
      _allUnits.Remove(unit);
      
      if(unit.Team == UnitTeam.First)
        _firstTeamUnitsUnits.Remove(unit);
      else
        _secondTeamUnits.Remove(unit);
    }
  }
}