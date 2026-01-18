using App.Scripts.Infrastructure.States;
using App.Scripts.Infrastructure.States.Game;
using App.Scripts.Infrastructure.UI;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Game.UI.Screens
{
  public class MenuScreen : BaseScreen
  {
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _randomizeButton;

    private IGameStateMachine _gameStateMachine;

    public void Construct(IGameStateMachine gameStateMachine)
    {
      _gameStateMachine = gameStateMachine;
      _startButton.onClick.AddListener(OnStartClicked);
      _randomizeButton.onClick.AddListener(OnRandomizeClicked);
    }

    private void OnStartClicked()
    {
      _gameStateMachine.Enter<GameLoopState>();
      Hide();
    }

    private void OnRandomizeClicked()
    {
      _gameStateMachine.Enter<SetupRandomUnitsState>();
    }
  }
}