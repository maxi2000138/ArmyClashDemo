using App.Scripts.Infrastructure.EntryPoints;
using App.Scripts.Utils.Extensions;
using Zenject;

namespace App.Scripts.Infrastructure.Installers.Project
{
  public class ProjectEntryPointInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.BindEntryPoint<ProjectEntryPoint>();
    }
  }

}