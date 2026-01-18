using App.Scripts.Infrastructure.States;
using Zenject;

namespace App.Scripts.Utils.Extensions
{
  public static class ZenjectExtensions
  {
    public static void BindEntryPoint<T>(this DiContainer container) where T : IInitializable => container.Bind<IInitializable>().To<T>().AsSingle();
    public static void BindState<T>(this DiContainer container) where T : IEnterState => container.Bind<IEnterState>().To<T>().AsSingle();
    public static void BindStateMachine<T>(this DiContainer container) where T : IGameStateMachine => container.BindInterfacesAndSelfTo<T>().AsSingle();
  }
}