using System.Collections.Generic;
using App.Scripts.Game;
using App.Scripts.Game.Factory;
using App.Scripts.Game.Unit;
using App.Scripts.Game.Unit.Features.Spawn.Data;
using App.Scripts.Game.Unit.Features.Spawn.Generator;
using App.Scripts.Game.Unit.Features.Stats.Data;
using App.Scripts.Infrastructure.StaticData;
using App.Scripts.Infrastructure.StaticData.BaseConfig;

namespace App.Scripts.Infrastructure.States.Game
{
  public class SetupRandomUnitsState : IEnterState
  {
    private readonly GameModel _gameModel;
    private readonly ISpawnDataGenerator _spawnDataGenerator;
    private readonly SceneConfig _sceneConfig;
    private readonly IGameFactory _gameFactory;
    private readonly IStaticDataService _staticData;

    public SetupRandomUnitsState(GameModel gameModel, ISpawnDataGenerator spawnDataGenerator,
      SceneConfig sceneConfig, IGameFactory gameFactory, IStaticDataService staticData)
    {
      _gameModel = gameModel;
      _spawnDataGenerator = spawnDataGenerator;
      _sceneConfig = sceneConfig;
      _gameFactory = gameFactory;
      _staticData = staticData;
    }

    public void Enter(IGameStateMachine stateMachine)
    {
      ClearAllUnits();

      var unitsPerTeam = _staticData.SpawnConfig.UnitsPerTeam;
      var firstTeamSpawnData = _spawnDataGenerator.GetRandomSpawnData(unitsPerTeam, _sceneConfig.FirstTeamZone);
      var secondTeamSpawnData = _spawnDataGenerator.GetRandomSpawnData(unitsPerTeam, _sceneConfig.SecondTeamZone);

      foreach (var spawnData in firstTeamSpawnData)
        _gameFactory.CreateUnit(spawnData.Stats, UnitTeam.First, spawnData.Position);

      foreach (var spawnData in secondTeamSpawnData)
        _gameFactory.CreateUnit(spawnData.Stats, UnitTeam.Second, spawnData.Position);
    }

    private void ClearAllUnits()
    {
      var allUnitsCopy = new List<GameUnit>(_gameModel.AllUnits);
      foreach (var unit in allUnitsCopy)
        _gameFactory.RemoveUnit(unit);
    }
  }
}

