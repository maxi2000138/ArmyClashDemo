using System.Collections.Generic;
using App.Scripts.Game.Field.Data;
using App.Scripts.Game.Unit.Stats;
using App.Scripts.Utils;
using UnityEngine;

namespace App.Scripts.Game.Field
{

  public class UnitSpawnDataGenerator : ISpawnDataGenerator
  {
    public IEnumerable<UnitSpawnData> GetRandomSpawnData(int amount, SpawnZone spawnZone)
    {
      for (var i = 0; i < amount; i++)
        yield return new UnitSpawnData(RandomForm(), RandomSize(), RandomColor(), RandomPosition(spawnZone));
    }

    private UnitColor RandomColor() => EnumExtensions.GetRandom<UnitColor>();
    private UnitForm RandomForm() => EnumExtensions.GetRandom<UnitForm>();
    private UnitSize RandomSize() => EnumExtensions.GetRandom<UnitSize>();
    private Vector3 RandomPosition(SpawnZone spawnZone)
    {
      var center = spawnZone.transform.position;
      var halfSizeX = spawnZone.Size.x * 0.5f;
      var halfSizeZ = spawnZone.Size.y * 0.5f;
      
      return new Vector3(
        center.x + Random.Range(-halfSizeX, halfSizeX),
        center.y,
        center.z + Random.Range(-halfSizeZ, halfSizeZ)
      );
    }
  }
}