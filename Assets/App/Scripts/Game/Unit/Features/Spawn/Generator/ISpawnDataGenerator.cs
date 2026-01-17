using System.Collections.Generic;
using App.Scripts.Game.Field.Data;

namespace App.Scripts.Game.Field
{
  public interface ISpawnDataGenerator
  {
    IEnumerable<UnitSpawnData> GetRandomSpawnData(int amount, SpawnZone spawnZone);
  }
}