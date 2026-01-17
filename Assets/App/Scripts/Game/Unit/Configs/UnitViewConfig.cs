using System;
using App.Scripts.Game.Unit.Stats;
using UnityEngine;
using UnityEngine.Rendering;

namespace App.Scripts.Game.Unit.Configs
{
  [Serializable]
  public class UnitViewConfig
  {
    public SerializedDictionary<UnitForm, GameUnit> Units;
    public SerializedDictionary<UnitSize, float> Sizes;
    public SerializedDictionary<UnitColor, Material> Materials;
  }
}