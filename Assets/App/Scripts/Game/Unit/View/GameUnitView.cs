using UnityEngine;

namespace App.Scripts.Game.Unit.View
{
  public class GameUnitView : MonoBehaviour
  {
    [SerializeField] private float CollisionScale = 1f;

    private Renderer _renderer;

    public float Height => transform.localScale.y;
    public float CollisionRadius => transform.localScale.x * CollisionScale;

    private void Awake()
    {
      _renderer = GetComponentInChildren<Renderer>();
    }

    public void UpdateColorAndSize(Material material, Vector3 size)
    {
      _renderer.material = material;
      transform.localScale = size;
      transform.localPosition = Vector3.up * size.y / 2f;
    }
  }
}