using System;
using Random = UnityEngine.Random;

namespace App.Scripts.Utils
{
  public static class EnumExtensions
  {
    public static T GetRandom<T>() where T : Enum
    {
      var values = Enum.GetValues(typeof(T));
      return (T)values.GetValue(Random.Range(0, values.Length));
    }
  }
}