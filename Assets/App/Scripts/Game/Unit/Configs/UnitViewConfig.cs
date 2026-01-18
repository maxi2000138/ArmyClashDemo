using System.Collections.Generic;
using App.Scripts.Game.Unit.Features.Stats.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Game.Unit.Configs
{
  [CreateAssetMenu(fileName = nameof(UnitViewConfig), menuName = "Configs/" + nameof(UnitViewConfig), order = -1000)]
  public class UnitViewConfig : SerializedScriptableObject
  {
    public Dictionary<UnitForm, GameUnit> Units;
    public Dictionary<UnitSize, float> Scales;
    public Dictionary<UnitColor, Material> Materials;
  }
}