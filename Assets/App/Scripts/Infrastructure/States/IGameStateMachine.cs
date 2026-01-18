using Zenject;

namespace App.Scripts.Infrastructure.States
{
  public interface IGameStateMachine : ITickable
  {
    void Enter<TState>() where TState : class, IEnterState;
  }
}