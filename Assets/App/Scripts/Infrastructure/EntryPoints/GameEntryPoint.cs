using App.Scripts.Infrastructure.States;
using App.Scripts.Infrastructure.States.Game;
using Zenject;

namespace App.Scripts.Infrastructure.EntryPoints
{
  public class GameEntryPoint : IInitializable
  {
    private readonly IGameStateMachine _gameStateMachine;
    public GameEntryPoint(IGameStateMachine gameStateMachine)
    {
      _gameStateMachine = gameStateMachine;
    }

    public void Initialize()
    {
      _gameStateMachine.Enter<MenuState>();
    }
  }
}