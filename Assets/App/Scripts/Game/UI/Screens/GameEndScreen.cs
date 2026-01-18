using App.Scripts.Game.Unit.Features.Stats.Data;
using App.Scripts.Infrastructure.States;
using App.Scripts.Infrastructure.States.Game;
using App.Scripts.Infrastructure.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Game.UI.Screens
{
  public class GameEndScreen : BaseScreen
  {
    [SerializeField] private TextMeshProUGUI _winnerText;
    [SerializeField] private Button _menuButton;

    private IGameStateMachine _gameStateMachine;

    public void Construct(IGameStateMachine gameStateMachine)
    {
      _gameStateMachine = gameStateMachine;
      _menuButton.onClick.AddListener(OnMenuClicked);
    }

    public void SetWinner(UnitTeam winnerTeam)
    {
      var winnerName = winnerTeam == UnitTeam.First ? "Первая команда" : "Вторая команда";
      _winnerText.text = $"Победила {winnerName}!";
    }

    private void OnMenuClicked()
    {
      _gameStateMachine.Enter<MenuState>();
      Hide();
    }
  }
}