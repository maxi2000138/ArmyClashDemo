using App.Scripts.Game.Unit.Features.Stats.Data;

namespace App.Scripts.Game.Unit.Features.Stats
{
  public struct UnitStats
  {
    public UnitForm Form;
    public UnitSize Size;
    public UnitColor Color;

    public UnitStats(UnitForm form, UnitSize size, UnitColor color)
    {
      Form = form;
      Size = size;
      Color = color;
    }
  }
}