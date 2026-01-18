using UnityEngine;

namespace App.Scripts.Utils
{
  public class Mathematics
  {
    public static float Epsilon => 0.001f;

    public static float Remap(float inputMin, float inputMax, float outputMin, float outputMax, float value) =>
      Mathf.Lerp(outputMin, outputMax, Mathf.InverseLerp(inputMin, inputMax, value));
  }
}