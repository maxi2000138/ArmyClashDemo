using App.Scripts.Game.Unit.Stats;
using UnityEngine;

namespace App.Scripts.Game.Field.Data
{
  public struct UnitSpawnData
  {
    public UnitStats Stats;
    public Vector3 Position;

    public UnitSpawnData(UnitForm form, UnitSize size, UnitColor color, Vector3 position)
    {
      Stats = new UnitStats(form, size, color);
      Position = position;
    }
  }
}