using App.Scripts.Game;
using App.Scripts.Game.Unit;
using App.Scripts.Game.Unit.Features.FindTarget;
using App.Scripts.Game.Unit.Features.Movement;
using UnityEngine;

namespace App.Scripts.Infrastructure.States.Game
{
  public class GameLoopState : IEnterState, ITickableState
  {
    private readonly GameModel _gameModel;
    private readonly IUnitMover _unitMover;
    private readonly IUnitTargetFinder _unitTargetFinder;
    public GameLoopState(GameModel gameModel, IUnitMover unitMover, IUnitTargetFinder unitTargetFinder)
    {
      _gameModel = gameModel;
      _unitMover = unitMover;
      _unitTargetFinder = unitTargetFinder;
    }

    public void Enter(IGameStateMachine stateMachine)
    {

    }

    public void Tick()
    {
      foreach (var unit in _gameModel.AllUnits)
      {
        UpdateTargetIfNeeded(unit);
        _unitMover.MoveToTarget(unit);
      }
    }

    private void UpdateTargetIfNeeded(GameUnit unit)
    {
      if (unit.Target != null)
        return;

      if (_unitTargetFinder.TryFindTarget(unit, out var target))
        unit.SetTarget(target);
    }
  }
}