using System.Collections.Generic;
using App.Scripts.Game.Factory;
using App.Scripts.Game.Unit.Features.Spawn.Data;
using App.Scripts.Game.Unit.Features.Spawn.Generator;
using App.Scripts.Game.Unit.Features.Stats.Data;
using App.Scripts.Infrastructure.StaticData.BaseConfig;
using UnityEngine;

namespace App.Scripts.Infrastructure.States.Game
{
  public class SetupUnitsState : IEnterState
  {
    private readonly ISpawnDataGenerator _spawnDataGenerator;
    private readonly SceneConfig _sceneConfig;
    private readonly IGameFactory _gameFactory;
    public SetupUnitsState(ISpawnDataGenerator spawnDataGenerator,
      SceneConfig sceneConfig, IGameFactory gameFactory)
    {
      _spawnDataGenerator = spawnDataGenerator;
      _sceneConfig = sceneConfig;
      _gameFactory = gameFactory;
    }

    public void Enter(IGameStateMachine stateMachine)
    {
      IEnumerable<UnitSpawnData> firstTeamSpawnData = _spawnDataGenerator.GetRandomSpawnData(20, _sceneConfig.FirstTeamZone);
      IEnumerable<UnitSpawnData> secondTeamSpawnData = _spawnDataGenerator.GetRandomSpawnData(20, _sceneConfig.SecondTeamZone);

      foreach (var spawnData in firstTeamSpawnData)
        _gameFactory.CreateUnit(spawnData.Stats, UnitTeam.First, spawnData.Position);

      foreach (var spawnData in secondTeamSpawnData)
        _gameFactory.CreateUnit(spawnData.Stats, UnitTeam.Second, spawnData.Position);

      stateMachine.Enter<GameLoopState>();
    }
  }
}