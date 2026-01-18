using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Game.Unit.Features.Health.View
{
  public class HealthView : MonoBehaviour
  {
    [SerializeField] private Image _fill;
    [SerializeField] private TextMeshProUGUI _text;

    public Image Fill => _fill;
    public TextMeshProUGUI Text => _text;
  }
}