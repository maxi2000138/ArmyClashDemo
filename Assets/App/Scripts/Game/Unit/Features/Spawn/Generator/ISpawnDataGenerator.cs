using System.Collections.Generic;
using App.Scripts.Game.Unit.Features.Spawn.Data;
using App.Scripts.Game.Unit.Features.Spawn.Zone;

namespace App.Scripts.Game.Unit.Features.Spawn.Generator
{
  public interface ISpawnDataGenerator
  {
    IEnumerable<UnitSpawnData> GetRandomSpawnData(int amount, SpawnZone spawnZone);
  }
}