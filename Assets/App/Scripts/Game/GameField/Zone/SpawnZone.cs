using System;
using App.Scripts.Utils;
using UnityEngine;

namespace App.Scripts.Game.Field
{
  [Serializable]
  public class SpawnZone : MonoBehaviour
  {
    public Vector2 Size;
    public Color EditorColor;
    
    private void OnDrawGizmos()
    {
      Gizmos.color = EditorColor;
      Gizmos.DrawWireCube(transform.position.AddY(0.5f), new Vector3(Size.x, 1f, Size.y));
    }
  }
}