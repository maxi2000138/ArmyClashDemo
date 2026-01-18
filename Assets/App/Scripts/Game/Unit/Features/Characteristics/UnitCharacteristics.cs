using App.Scripts.Game.Unit.Features.Characteristics.Data;

namespace App.Scripts.Game.Unit.Features.Characteristics
{
  public class UnitCharacteristics
  {
    public float Hp { get; private set; }
    public float Atk { get; private set; }
    public float Speed { get; private set; }
    public float AtkSpd { get; private set; }

    public UnitCharacteristics(float baseHp, float baseAtk, float baseSpeed, float baseAtkSpd)
    {
      Hp = baseHp;
      Atk = baseAtk;
      Speed = baseSpeed;
      AtkSpd = baseAtkSpd;
    }

    public void ApplyModifiers(CharacteristicModifiers modifiers)
    {
      Hp += modifiers.HpModifier;
      Atk += modifiers.AtkModifier;
      Speed += modifiers.SpeedModifier;
      AtkSpd += modifiers.AtkSpdModifier;
    }
  }
}