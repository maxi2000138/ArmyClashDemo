using App.Scripts.Game.Unit.Features.FindTarget;
using App.Scripts.Game.Unit.Features.Movement;
using App.Scripts.Game.Unit.Stats;
using UnityEngine;

namespace App.Scripts.Game.Unit
{
  public class GameUnit : MonoBehaviour
  {
    [field: SerializeField] public GameUnitView View { get; private set; }
    
    public GameUnit Target { get; private set; }
    public UnitTeam Team { get; private set; }

    public void Construct(UnitTeam team)
    {
      Team = team;
    }

    public void SetTarget(GameUnit target)
    {
      Target = target;
    }
  }
}