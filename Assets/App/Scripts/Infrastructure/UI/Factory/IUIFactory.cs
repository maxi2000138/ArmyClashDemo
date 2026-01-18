using App.Scripts.Game.Unit;
using App.Scripts.Game.Unit.Features.Stats.View;
using App.Scripts.Infrastructure.UI.Data;
using UnityEngine;

namespace App.Scripts.Infrastructure.UI.Factory
{
  public interface IUIFactory
  {
    BaseScreen CreateScreen(ScreenType screenType);
    UnitViewStats CreateUnitViewStats(GameUnit unit, Transform parent);
    void DestroyUnitStats(UnitViewStats unitViewStats);
  }
}