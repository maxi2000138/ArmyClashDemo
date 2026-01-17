using UnityEngine;

namespace App.Scripts.Game.Unit
{
  public class GameUnitView : MonoBehaviour
  {
    private Renderer _renderer;
    
    private void Awake()
    {
      _renderer = GetComponentInChildren<Renderer>();
    }

    public void UpdateColorAndSize(Material material, Vector3 size)
    {
      _renderer.material = material;
      transform.localScale = size;
    }
  }
}