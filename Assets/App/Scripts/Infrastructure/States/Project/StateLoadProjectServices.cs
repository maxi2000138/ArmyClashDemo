using App.Scripts.Infrastructure.StaticData;
using UnityEngine;

namespace App.Scripts.Infrastructure.States.Project
{
  public class StateLoadProjectServices : IEnterState
  {
    private readonly IStaticDataService _staticData;

    public StateLoadProjectServices(IStaticDataService staticData)
    {
      _staticData = staticData;
    }

    public void Enter(IGameStateMachine stateMachine)
    {
      _staticData.Load();
    }
  }
}