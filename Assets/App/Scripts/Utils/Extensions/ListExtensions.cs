using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace App.Scripts.Utils
{
  public static class ListExtensions
  {
    public static T PickRandomOrDefault<T>(this IList<T> list)
    {
      if (list == null) 
        throw new ArgumentNullException(nameof(list));
                
      if (list.Count == 0)
        return default;
            
      return list[Random.Range(0, list.Count)];
    }
  }
}