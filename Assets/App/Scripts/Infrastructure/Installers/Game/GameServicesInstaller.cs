using App.Scripts.Game;
using App.Scripts.Game.Factory;
using App.Scripts.Game.Unit.Features.Attack;
using App.Scripts.Game.Unit.Features.FindTarget;
using App.Scripts.Game.Unit.Features.Health;
using App.Scripts.Game.Unit.Features.Movement;
using App.Scripts.Game.Unit.Features.Spawn.Generator;
using App.Scripts.Game.Unit.Features.Stats.View;
using App.Scripts.Infrastructure.Camera;
using App.Scripts.Infrastructure.StaticData.BaseConfig;
using App.Scripts.Infrastructure.UI.Factory;
using App.Scripts.Infrastructure.UI.ScreenService;
using UnityEngine;
using Zenject;

namespace App.Scripts.Infrastructure.Installers.Game
{
  public class GameServicesInstaller : MonoInstaller
  {
    [SerializeField] private CameraService _cameraService;
    [SerializeField] private SceneConfig _sceneConfig;

    public override void InstallBindings()
    {
      Container.Bind<ICameraService>().FromInstance(_cameraService);
      Container.Bind<SceneConfig>().FromInstance(_sceneConfig);

      Container.Bind<GameModel>().AsSingle();

      Container.Bind<IUnitMover>().To<UnitMover>().AsSingle();
      Container.Bind<IUnitAttacker>().To<UnitAttacker>().AsSingle();
      Container.BindInterfacesAndSelfTo<UniViewStatsUpdater>().AsSingle();
      Container.Bind<IUnitTargetFinder>().To<UnitTargetFinder>().AsSingle();
      Container.Bind<ISpawnDataGenerator>().To<UnitSpawnDataGenerator>().AsSingle();
      Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
      Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
      Container.Bind<IScreenService>().To<ScreenService>().AsSingle();
    }
  }
}