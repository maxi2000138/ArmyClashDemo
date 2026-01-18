using App.Scripts.Infrastructure.States;
using App.Scripts.Infrastructure.States.Project;
using App.Scripts.Utils.Extensions;
using Zenject;

namespace App.Scripts.Infrastructure.Installers.Project
{
  public class ProjectStatesInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.BindState<StateLoadProjectServices>();
      Container.BindStateMachine<GameStateMachine>();
    }
  }
}