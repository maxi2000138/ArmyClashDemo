using UnityEngine;

namespace App.Scripts.Infrastructure.Camera
{
  public interface ICameraService
  {
    UnityEngine.Camera Camera { get; }
    bool IsOnScreen(Vector3 viewportPoint);
  }
}