using App.Scripts.Game.Unit.Configs;
using App.Scripts.Game.Unit.Features.Health;
using App.Scripts.Game.Unit.Features.Movement.Configs;
using App.Scripts.Infrastructure.UI.Configs;

namespace App.Scripts.Infrastructure.StaticData
{
  public interface IStaticDataService
  {
    UiPrefabsConfig UiPrefabsConfig { get; }
    ScreensConfig ScreensConfig { get; }
    UnitViewConfig UnitViewConfig { get; }
    MovementConfig MovementConfig { get; }

    void Load();
  }
}