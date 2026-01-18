using App.Scripts.Game.Unit.Features.Stats.View;
using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Infrastructure.UI.Configs
{
  [CreateAssetMenu(fileName = nameof(UiPrefabsConfig), menuName = "Configs/" + nameof(UiPrefabsConfig), order = -1000)]
  public class UiPrefabsConfig : SerializedScriptableObject
  {
    public UnitViewStats UnitViewStats;
  }
}