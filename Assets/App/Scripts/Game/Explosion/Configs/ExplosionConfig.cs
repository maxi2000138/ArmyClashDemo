using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Game.Explosion.Configs
{
  [CreateAssetMenu(fileName = nameof(ExplosionConfig), menuName = "Configs/" + nameof(ExplosionConfig), order = -1000)]
  public class ExplosionConfig : SerializedScriptableObject
  {
    [MinValue(0.1f)]
    public float Radius = 5f;

    [MinValue(0.1f)]
    public float PushForce = 10f;
  }
}