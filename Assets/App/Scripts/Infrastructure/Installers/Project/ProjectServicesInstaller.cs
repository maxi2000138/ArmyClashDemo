using App.Scripts.Infrastructure.StaticData;
using Zenject;

namespace App.Scripts.Infrastructure.Installers.Project
{
  public class ProjectServicesInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
    }
  }
}