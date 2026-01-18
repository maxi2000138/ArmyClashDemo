using App.Scripts.Infrastructure.EntryPoints;
using App.Scripts.Utils.Extensions;
using Zenject;

namespace App.Scripts.Infrastructure.Installers.Game
{
  public class GameEntryPointInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.BindEntryPoint<GameEntryPoint>();
    }
  }
}