using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Game.Unit.Features.Spawn.Configs
{
  [CreateAssetMenu(fileName = nameof(SpawnConfig), menuName = "Configs/" + nameof(SpawnConfig), order = -1000)]
  public class SpawnConfig : SerializedScriptableObject
  {
    public int UnitsPerTeam = 20;
  }
}