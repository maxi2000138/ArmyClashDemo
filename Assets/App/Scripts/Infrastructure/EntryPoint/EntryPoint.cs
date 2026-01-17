using App.Scripts.Game;
using App.Scripts.Game.Factory;
using App.Scripts.Game.Field;
using App.Scripts.Game.Field.Configs;
using App.Scripts.Game.Unit.Configs;
using App.Scripts.Game.Unit.Features.FindTarget;
using App.Scripts.Game.Unit.Features.Movement;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
  [SerializeField] private GameSimulation _gameSimulation;
  
  [Header("Configs")]
  [SerializeField] private UnitViewConfig _unitViewConfig;
  [SerializeField] private FieldConfig _gameFieldConfig;
  
  private SimulationModel _simulationModel;
  private IGameFactory _gameFactory;
  private ISpawnDataGenerator _spawnDataGenerator;
  private UnitMover _unitMover;
  private UnitTargetFinder _unitTargetFinder;


  private void Start()
  {
    CompositionRoot();
    _gameSimulation.Simulate();
  }

  private void CompositionRoot()
  {
    _simulationModel = new SimulationModel();
    _unitMover = new UnitMover();
    _unitTargetFinder = new UnitTargetFinder(_simulationModel);
    _gameFactory = new GameFactory(_unitViewConfig, _gameFieldConfig, _simulationModel);
    _spawnDataGenerator = new UnitSpawnDataGenerator();
    _gameSimulation.Construct(_simulationModel, _unitMover, _unitTargetFinder, _spawnDataGenerator, _gameFactory, _gameFieldConfig);
  }
}
