using App.Scripts.Game.Unit.Configs;
using App.Scripts.Game.Unit.Features.Movement.Configs;
using App.Scripts.Infrastructure.UI.Configs;
using UnityEngine;

namespace App.Scripts.Infrastructure.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    private const string ConfigsPath = "Configs/";

    public ScreensConfig ScreensConfig { get; private set; }
    public UnitViewConfig UnitViewConfig { get; private set; }
    public MovementConfig MovementConfig { get; private set; }
    public UiPrefabsConfig UiPrefabsConfig { get; private set; }


    public void Load()
    {
      ScreensConfig = LoadConfig<ScreensConfig>();
      UnitViewConfig = LoadConfig<UnitViewConfig>();
      MovementConfig = LoadConfig<MovementConfig>();
      UiPrefabsConfig = LoadConfig<UiPrefabsConfig>();
    }

    private T LoadConfig<T>() where T : ScriptableObject => Resources.Load<T>(ConfigsPath + typeof(T).Name);
  }
}