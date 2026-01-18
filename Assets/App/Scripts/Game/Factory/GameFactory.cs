using App.Scripts.Game.Unit;
using App.Scripts.Game.Unit.Configs;
using App.Scripts.Game.Unit.Features.Health;
using App.Scripts.Game.Unit.Features.Stats;
using App.Scripts.Game.Unit.Features.Stats.Data;
using App.Scripts.Game.Unit.Features.Stats.View;
using App.Scripts.Infrastructure.StaticData;
using App.Scripts.Infrastructure.StaticData.BaseConfig;
using App.Scripts.Infrastructure.UI.Factory;
using UnityEngine;

namespace App.Scripts.Game.Factory
{
  public class GameFactory : IGameFactory
  {
    private readonly GameModel _gameModel;
    private readonly IUIFactory _uiFactory;
    private readonly SceneConfig _sceneConfig;
    private readonly IStaticDataService _staticData;
    private readonly UniViewStatsUpdater _uniViewStatsUpdater;

    public GameFactory(IStaticDataService staticData, SceneConfig sceneConfig, GameModel gameModel,
      IUIFactory uiFactory, UniViewStatsUpdater uniViewStatsUpdater)
    {
      _staticData = staticData;
      _sceneConfig = sceneConfig;
      _gameModel = gameModel;
      _uiFactory = uiFactory;
      _uniViewStatsUpdater = uniViewStatsUpdater;
    }

    public GameUnit CreateUnit(UnitStats stats, UnitTeam team, Vector3 at)
    {
      var prefab = _staticData.UnitViewConfig.Units[stats.Form];
      var material = _staticData.UnitViewConfig.Materials[stats.Color];
      var size = _staticData.UnitViewConfig.Scales[stats.Size];

      var unit = Object.Instantiate(prefab, at, Quaternion.identity, _sceneConfig.EnemiesParent);

      unit.Construct(team);

      unit.View.UpdateColorAndSize(material, Vector3.one * size);
      var unitViewStats = _uiFactory.CreateUnitViewStats(unit, _sceneConfig.HealthViewsParent);
      _uniViewStatsUpdater.AddUnitStats(unitViewStats);

      unit.Health.SetMaxValue(10);
      unit.Health.SetCurrentHealth(10);

      _gameModel.AddUnit(unit);

      return unit;
    }

    public void RemoveUnit(GameUnit unit)
    {
      _gameModel.RemoveUnit(unit);
      Object.Destroy(unit);
    }
  }
}