namespace App.Scripts.Game.Unit.Features.Characteristics.Data
{
  public struct CharacteristicModifiers
  {
    public float HpModifier;
    public float AtkModifier;
    public float SpeedModifier;
    public float AtkSpdModifier;

    public CharacteristicModifiers(float hpModifier, float atkModifier, float speedModifier, float atkSpdModifier)
    {
      HpModifier = hpModifier;
      AtkModifier = atkModifier;
      SpeedModifier = speedModifier;
      AtkSpdModifier = atkSpdModifier;
    }
  }
}