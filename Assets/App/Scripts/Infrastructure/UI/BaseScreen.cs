using UnityEngine;

namespace App.Scripts.Infrastructure.UI
{
  public class BaseScreen : MonoBehaviour
  {
    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);
  }
}