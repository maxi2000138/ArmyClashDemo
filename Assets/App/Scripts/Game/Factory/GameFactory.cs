using App.Scripts.Game.Unit;
using App.Scripts.Game.Unit.Configs;
using App.Scripts.Game.Unit.Features.Characteristics;
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
    private readonly UnitCharacteristicsApplier _characteristicsApplier;

    public GameFactory(IStaticDataService staticData, SceneConfig sceneConfig, GameModel gameModel,
      IUIFactory uiFactory, UniViewStatsUpdater uniViewStatsUpdater, UnitCharacteristicsApplier characteristicsApplier)
    {
      _staticData = staticData;
      _sceneConfig = sceneConfig;
      _gameModel = gameModel;
      _uiFactory = uiFactory;
      _uniViewStatsUpdater = uniViewStatsUpdater;
      _characteristicsApplier = characteristicsApplier;
    }

    public GameUnit CreateUnit(UnitStats stats, UnitTeam team, Vector3 at)
    {
      var prefab = _staticData.UnitViewConfig.Units[stats.Form];
      var material = _staticData.UnitViewConfig.Materials[stats.Color];
      var size = _staticData.UnitViewConfig.Scales[stats.Size];

      var unit = Object.Instantiate(prefab, at, Quaternion.identity, _sceneConfig.EnemiesParent);

      var characteristicsConfig = _staticData.UnitCharacteristicsConfig;
      unit.Construct(team, characteristicsConfig.BaseHp, characteristicsConfig.BaseAtk,
        characteristicsConfig.BaseSpeed, characteristicsConfig.BaseAtkSpd);

      _characteristicsApplier.ApplyModifiers(unit, stats);
      unit.SetStats(stats);

      unit.View.UpdateColorAndSize(material, Vector3.one * size);
      var unitViewStats = _uiFactory.CreateUnitViewStats(unit, _sceneConfig.HealthViewsParent);
      _uniViewStatsUpdater.AddUnitStats(unitViewStats);

      unit.Health.SetMaxValue(unit.Characteristics.Hp);
      unit.Health.SetCurrentHealth(unit.Characteristics.Hp);

      _gameModel.AddUnit(unit);

      return unit;
    }

    public void RemoveUnit(GameUnit unit)
    {
      _gameModel.RemoveUnit(unit);
      _uniViewStatsUpdater.DestroyUnitStats(unit);

      Object.Destroy(unit.gameObject);
    }
  }
}