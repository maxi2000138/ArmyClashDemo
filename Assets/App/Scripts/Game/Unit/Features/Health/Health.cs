using System;
using UnityEngine;

namespace App.Scripts.Game.Unit.Features.Health
{
  public class Health
  {
    public float Value { get; private set; }
    public float MaxValue { get; private set; }

    public event Action OnHealthChanged;

    public void SetCurrentHealth(float value)
    {
      if (value < 0)
        value = 0;

      if (value > MaxValue)
        value = MaxValue;

      Value = value;
      OnHealthChanged?.Invoke();
    }

    public void SetMaxValue(float maxValue)
    {
      if (maxValue < 0)
        maxValue = 0;

      MaxValue = maxValue;
      OnHealthChanged?.Invoke();
    }

    public override string ToString() => string.Format("{0}/{1}", Mathf.Clamp(Value, 0, MaxValue).ToString(), MaxValue.ToString());
  }
}