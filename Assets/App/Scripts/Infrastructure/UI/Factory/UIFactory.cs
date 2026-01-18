using App.Scripts.Game.Unit;
using App.Scripts.Game.Unit.Features.Health;
using App.Scripts.Game.Unit.Features.Stats.View;
using App.Scripts.Infrastructure.StaticData;
using App.Scripts.Infrastructure.UI.Data;
using UnityEngine;

namespace App.Scripts.Infrastructure.UI.Factory
{
  public class UIFactory : IUIFactory
  {
    private readonly IStaticDataService _staticData;

    public UIFactory(IStaticDataService staticData)
    {
      _staticData = staticData;
    }

    public BaseScreen CreateScreen(ScreenType screenType)
    {
      var baseScreen = _staticData.ScreensConfig.Screens[screenType];
      return Object.Instantiate(baseScreen);
    }

    public UnitViewStats CreateUnitViewStats(GameUnit unit, Transform parent)
    {
      var prefab = _staticData.UiPrefabsConfig.UnitViewStats;
      var unitStats = Object.Instantiate(prefab, parent);
      unitStats.SetUnit(unit);
      return unitStats;
    }
  }
}