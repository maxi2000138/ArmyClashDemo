using System.Linq;
using App.Scripts.Game.Field.Configs;
using App.Scripts.Game.Unit;
using App.Scripts.Game.Unit.Configs;
using App.Scripts.Game.Unit.Features.FindTarget;
using App.Scripts.Game.Unit.Features.Movement;
using App.Scripts.Game.Unit.Stats;
using UnityEngine;

namespace App.Scripts.Game.Factory
{
  public class GameFactory : IGameFactory
  {
    private readonly UnitViewConfig _unitViewConfig;
    private readonly FieldConfig _gameFieldConfig;
    private readonly SimulationModel _simulationModel;

    public GameFactory(UnitViewConfig unitViewConfig, FieldConfig gameFieldConfig, SimulationModel simulationModel)
    {
      _unitViewConfig = unitViewConfig;
      _gameFieldConfig = gameFieldConfig;
      _simulationModel = simulationModel;
    }
    
    public GameUnit CreateUnit(UnitStats stats, UnitTeam team, Vector3 at)
    {
      var prefab = _unitViewConfig.Units[stats.Form];
      var material = _unitViewConfig.Materials[stats.Color];
      var size = _unitViewConfig.Sizes[stats.Size];
      
      var unit = Object.Instantiate(prefab, at, Quaternion.identity, _gameFieldConfig.EnemiesParent);
      
      unit.Construct(team);
      unit.View.UpdateColorAndSize(material, Vector3.one * size);
      
      _simulationModel.AddUnit(unit);
      
      return unit;
    }
    
    public void RemoveUnit(GameUnit unit)
    {
      _simulationModel.RemoveUnit(unit);
      Object.Destroy(unit);
    }
  }
}
