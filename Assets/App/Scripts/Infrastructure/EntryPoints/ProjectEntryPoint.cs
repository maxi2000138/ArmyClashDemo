using App.Scripts.Infrastructure.States;
using App.Scripts.Infrastructure.States.Project;
using Zenject;

namespace App.Scripts.Infrastructure.EntryPoints
{
  public class ProjectEntryPoint : IInitializable
  {
    private readonly IGameStateMachine _gameStateMachine;
    public ProjectEntryPoint(IGameStateMachine gameStateMachine)
    {
      _gameStateMachine = gameStateMachine;
    }

    public void Initialize()
    {
      _gameStateMachine.Enter<StateLoadProjectServices>();
    }
  }
}