using System;
using System.Collections.Generic;

namespace App.Scripts.Infrastructure.States
{
  public sealed class GameStateMachine : IGameStateMachine
  {
    private readonly Dictionary<Type, IEnterState> _states;

    private IEnterState _activeState;

    public GameStateMachine(IEnumerable<IEnterState> states)
    {
      _states = new Dictionary<Type, IEnterState>();
      foreach (var state in states)
        _states.Add(state.GetType(), state);
    }

    void IGameStateMachine.Enter<TState>()
    {
      var state = ChangeState<TState>();
      state.Enter(this);
    }

    public void Tick()
    {
      if (_activeState is ITickableState tickableState)
        tickableState.Tick();
    }

    private TState ChangeState<TState>() where TState : class, IEnterState
    {
      if (_activeState is IExitState exitState)
        exitState.Exit();

      var state = GetState<TState>();
      _activeState = state;
      return state;
    }

    private TState GetState<TState>() where TState : class, IEnterState => _states[typeof(TState)] as TState;
  }
}