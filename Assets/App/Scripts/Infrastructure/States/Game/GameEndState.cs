using System.Collections.Generic;
using System.Linq;
using App.Scripts.Game;
using App.Scripts.Game.UI.Screens;
using App.Scripts.Game.Unit;
using App.Scripts.Game.Unit.Features.Stats.Data;
using App.Scripts.Infrastructure.UI.Data;
using App.Scripts.Infrastructure.UI.ScreenService;

namespace App.Scripts.Infrastructure.States.Game
{
  public class GameEndState : IEnterState
  {
    private readonly IScreenService _screenService;
    private readonly GameModel _gameModel;

    public GameEndState(IScreenService screenService, GameModel gameModel)
    {
      _screenService = screenService;
      _gameModel = gameModel;
    }

    public void Enter(IGameStateMachine stateMachine)
    {
      var winnerTeam = DetermineWinner();
      var gameEndScreen = _screenService.OpenScreen(ScreenType.GameEnd) as GameEndScreen;
      gameEndScreen.Construct(stateMachine);
      gameEndScreen.SetWinner(winnerTeam);
    }

    private UnitTeam DetermineWinner()
    {
      var firstTeamHasAlive = HasAliveUnits(_gameModel.FirstTeamUnits);
      return firstTeamHasAlive ? UnitTeam.First : UnitTeam.Second;
    }

    private bool HasAliveUnits(IEnumerable<GameUnit> units) =>
      units.Any(unit => unit.IsAlive);
  }
}