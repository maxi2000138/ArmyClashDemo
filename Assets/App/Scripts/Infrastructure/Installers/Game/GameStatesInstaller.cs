using App.Scripts.Infrastructure.States;
using App.Scripts.Infrastructure.States.Game;
using App.Scripts.Utils.Extensions;
using Zenject;

namespace App.Scripts.Infrastructure.Installers.Game
{
  public class GameStatesInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.BindState<MenuState>();
      Container.BindState<SetupRandomUnitsState>();
      Container.BindState<GameLoopState>();
      Container.BindState<GameEndState>();
      Container.BindStateMachine<GameStateMachine>();
    }
  }
}