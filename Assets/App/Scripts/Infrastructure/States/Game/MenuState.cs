using App.Scripts.Game.UI.Screens;
using App.Scripts.Infrastructure.UI.Data;
using App.Scripts.Infrastructure.UI.ScreenService;

namespace App.Scripts.Infrastructure.States.Game
{
  public class MenuState : IEnterState
  {
    private readonly IScreenService _screenService;

    public MenuState(IScreenService screenService)
    {
      _screenService = screenService;
    }

    public void Enter(IGameStateMachine stateMachine)
    {
      var menuScreen = _screenService.OpenScreen(ScreenType.Menu) as MenuScreen;
      menuScreen.Construct(stateMachine);

      stateMachine.Enter<SetupRandomUnitsState>();
    }
  }
}