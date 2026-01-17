using App.Scripts.Game.Factory;
using App.Scripts.Game.Field;
using App.Scripts.Game.Field.Configs;
using App.Scripts.Game.Unit;
using App.Scripts.Game.Unit.Features.FindTarget;
using App.Scripts.Game.Unit.Features.Movement;
using App.Scripts.Game.Unit.Stats;
using UnityEngine;

namespace App.Scripts.Game
{
  public class GameSimulation : MonoBehaviour
  {
    private ISpawnDataGenerator _spawnDataGenerator;
    private UnitTargetFinder _unitTargetFinder;
    private SimulationModel _simulationModel;
    private IGameFactory _gameFactory;
    private UnitMover _unitMover;
    private FieldConfig _fieldConfig;

    private bool _simulating;

    public void Construct(SimulationModel simulationModel, UnitMover unitMover, 
      UnitTargetFinder unitTargetFinder, ISpawnDataGenerator spawnDataGenerator, 
      IGameFactory gameFactory, FieldConfig fieldConfig)
    {
      _fieldConfig = fieldConfig;
      _spawnDataGenerator = spawnDataGenerator;
      _unitTargetFinder = unitTargetFinder;
      _simulationModel = simulationModel;
      _gameFactory = gameFactory;
      _unitMover = unitMover;
    }
    
    public void Simulate()
    {
      var firstTeamSpawnData = _spawnDataGenerator.GetRandomSpawnData(20, _fieldConfig.FirstTeam);
      var secondTeamSpawnData = _spawnDataGenerator.GetRandomSpawnData(20, _fieldConfig.SecondTeam);
      
      foreach (var spawnData in firstTeamSpawnData)
        _gameFactory.CreateUnit(spawnData.Stats, UnitTeam.First, spawnData.Position);
      
      foreach (var spawnData in secondTeamSpawnData)
        _gameFactory.CreateUnit(spawnData.Stats, UnitTeam.Second, spawnData.Position);
      
      _simulating = true;
    }
    
    public void StopSimulation()
    {
      _simulating = false;
    }
    
    public void Update()
    {
      if (!_simulating)
        return;
      
      foreach (var unit in _simulationModel.AllUnits)
      {
        UpdateTargetIfNeeded(unit);
        _unitMover.MoveToTarget(unit);
      }
    }
    
    private void UpdateTargetIfNeeded(GameUnit unit)
    {
      if (unit.Target != null) 
        return;
      
      if (_unitTargetFinder.TryFindTarget(unit, out var target))
        unit.SetTarget(target);
    }
  }
}