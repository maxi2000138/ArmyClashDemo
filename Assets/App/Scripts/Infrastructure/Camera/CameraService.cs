using UnityEngine;

namespace App.Scripts.Infrastructure.Camera
{
  public sealed class CameraService : MonoBehaviour, ICameraService
  {
    [SerializeField] private UnityEngine.Camera _camera;

    public UnityEngine.Camera Camera => _camera;

    public bool IsOnScreen(Vector3 viewportPoint) => viewportPoint is { x: > 0f and < 1f, y: > 0f and < 1f };
  }
}