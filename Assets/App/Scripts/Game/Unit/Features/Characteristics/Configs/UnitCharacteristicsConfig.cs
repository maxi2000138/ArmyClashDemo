using System.Collections.Generic;
using App.Scripts.Game.Unit.Features.Characteristics.Data;
using App.Scripts.Game.Unit.Features.Stats.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Game.Unit.Features.Characteristics.Configs
{
  [CreateAssetMenu(fileName = nameof(UnitCharacteristicsConfig), menuName = "Configs/" + nameof(UnitCharacteristicsConfig), order = -1000)]
  public class UnitCharacteristicsConfig : SerializedScriptableObject
  {
    [Title("Base Characteristics")]
    public float BaseHp = 100f;
    public float BaseAtk = 10f;
    public float BaseSpeed = 10f;
    public float BaseAtkSpd = 1f;

    [Title("Form Modifiers")]
    public Dictionary<UnitForm, CharacteristicModifiers> FormModifiers = new Dictionary<UnitForm, CharacteristicModifiers>();

    [Title("Size Modifiers")]
    public Dictionary<UnitSize, CharacteristicModifiers> SizeModifiers = new Dictionary<UnitSize, CharacteristicModifiers>();

    [Title("Color Modifiers")]
    public Dictionary<UnitColor, CharacteristicModifiers> ColorModifiers = new Dictionary<UnitColor, CharacteristicModifiers>();
  }
}