using App.Scripts.Game.Unit.Features.Health;
using App.Scripts.Game.Unit.Features.Health.View;
using TMPro;
using UnityEngine;

namespace App.Scripts.Game.Unit.Features.Stats.View
{
  public class UnitViewStats : MonoBehaviour
  {
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TextMeshProUGUI _teamText;
    [SerializeField] private HealthView _healthView;

    public GameUnit Unit { get; private set; }
    public CanvasGroup CanvasGroup => _canvasGroup;
    public HealthView HealthView => _healthView;

    public void SetUnit(GameUnit unit)
    {
      Unit = unit;
      _teamText.text = ((int)unit.Team).ToString();
    }
  }
}