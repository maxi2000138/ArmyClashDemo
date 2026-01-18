using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Game.Unit.Features.Attack.Configs
{
  [CreateAssetMenu(fileName = nameof(AttackConfig), menuName = "Configs/" + nameof(AttackConfig), order = -1000)]
  public class AttackConfig : SerializedScriptableObject
  {
    public float AttackRadius = 1.0f;
  }
}