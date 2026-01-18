using System.Collections.Generic;
using App.Scripts.Game;
using App.Scripts.Game.Factory;
using App.Scripts.Game.Unit;
using App.Scripts.Game.Unit.Features.Attack;
using App.Scripts.Game.Unit.Features.FindTarget;
using App.Scripts.Game.Unit.Features.Movement;
using App.Scripts.Game.Unit.Features.Stats.Data;
using App.Scripts.Infrastructure.UI.ScreenService;

namespace App.Scripts.Infrastructure.States.Game
{
  public class GameLoopState : IEnterState, ITickableState
  {
    private readonly List<GameUnit> _deadUnits = new List<GameUnit>();

    private readonly GameModel _gameModel;
    private readonly IGameFactory _gameFactory;
    private readonly IUnitMover _unitMover;
    private readonly IUnitTargetFinder _unitTargetFinder;
    private readonly IUnitAttacker _unitAttacker;
    private readonly IScreenService _screenService;

    private IGameStateMachine _stateMachine;

    public GameLoopState(GameModel gameModel, IGameFactory gameFactory, IUnitMover unitMover,
      IUnitTargetFinder unitTargetFinder, IUnitAttacker unitAttacker, IScreenService screenService)
    {
      _gameModel = gameModel;
      _gameFactory = gameFactory;
      _unitMover = unitMover;
      _unitTargetFinder = unitTargetFinder;
      _unitAttacker = unitAttacker;
      _screenService = screenService;
    }

    public void Enter(IGameStateMachine stateMachine)
    {
      _stateMachine = stateMachine;
    }

    public void Tick()
    {
      foreach (var unit in _gameModel.AllUnits)
      {
        UpdateTargetIfNeeded(unit);

        if (_unitAttacker.TryAttack(unit))
        {
          if (!unit.Target.IsAlive)
            MarkDead(unit);
        }
        else
        {
          _unitMover.MoveToTarget(unit);
        }
      }

      RemoveDeadUnits();

      CheckGameEnd();
    }

    private void UpdateTargetIfNeeded(GameUnit unit)
    {
      if (unit.Target != null && unit.Target.IsAlive)
        return;

      unit.SetTarget(null);

      if (_unitTargetFinder.TryFindTarget(unit, out var target))
        unit.SetTarget(target);
    }

    private void MarkDead(GameUnit unit) => _deadUnits.Add(unit.Target);

    private void RemoveDeadUnits()
    {
      if (_deadUnits.Count > 0)
      {
        foreach (var unit in _deadUnits)
          _gameFactory.RemoveUnit(unit);

        _deadUnits.Clear();
      }
    }

    private void CheckGameEnd()
    {
      var firstTeamAlive = HasAliveUnits(_gameModel.FirstTeamUnits);
      var secondTeamAlive = HasAliveUnits(_gameModel.SecondTeamUnits);

      if (firstTeamAlive && secondTeamAlive)
        return;

      _stateMachine.Enter<GameEndState>();
    }

    private bool HasAliveUnits(IReadOnlyList<GameUnit> units)
    {
      foreach (var unit in units)
      {
        if (unit.IsAlive)
          return true;
      }

      return false;
    }
  }
}