using App.Scripts.Game.Unit;
using App.Scripts.Game.Unit.Features.Characteristics.Configs;
using App.Scripts.Game.Unit.Features.Stats;
using App.Scripts.Game.Unit.Features.Stats.Data;
using App.Scripts.Infrastructure.StaticData;

namespace App.Scripts.Game.Unit.Features.Characteristics
{
  public class UnitCharacteristicsApplier
  {
    private readonly IStaticDataService _staticData;

    private UnitCharacteristicsConfig Config => _staticData.UnitCharacteristicsConfig;

    public UnitCharacteristicsApplier(IStaticDataService staticData)
    {
      _staticData = staticData;
    }

    public void ApplyModifiers(GameUnit unit, UnitStats stats)
    {
      if (Config.FormModifiers.TryGetValue(stats.Form, out var formModifiers))
        unit.Characteristics.ApplyModifiers(formModifiers);

      if (Config.SizeModifiers.TryGetValue(stats.Size, out var sizeModifiers))
        unit.Characteristics.ApplyModifiers(sizeModifiers);

      if (Config.ColorModifiers.TryGetValue(stats.Color, out var colorModifiers))
        unit.Characteristics.ApplyModifiers(colorModifiers);
    }

    public void ReconfigureFromBase(GameUnit unit, UnitStats stats)
    {
      unit.Characteristics.ReconfigureFromBase(Config.BaseHp, Config.BaseAtk, Config.BaseSpeed, Config.BaseAtkSpd);
      ApplyModifiers(unit, stats);
    }

    public void ReconfigureWithNewColor(GameUnit unit, UnitColor newColor)
    {
      var stats = unit.CurrentStats;
      var newStats = stats;
      newStats.Color = newColor;

      ReconfigureFromBase(unit, newStats);
    }
  }
}