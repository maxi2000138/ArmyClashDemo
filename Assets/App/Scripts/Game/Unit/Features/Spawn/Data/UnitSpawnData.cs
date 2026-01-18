using App.Scripts.Game.Unit.Features.Stats;
using App.Scripts.Game.Unit.Features.Stats.Data;
using UnityEngine;

namespace App.Scripts.Game.Unit.Features.Spawn.Data
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