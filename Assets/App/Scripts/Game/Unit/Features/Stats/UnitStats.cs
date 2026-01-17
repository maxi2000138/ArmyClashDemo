namespace App.Scripts.Game.Unit.Stats
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