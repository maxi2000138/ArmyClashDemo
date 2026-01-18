using App.Scripts.Game.Unit.Features.Health;
using App.Scripts.Game.Unit.Features.Stats.Data;
using App.Scripts.Game.Unit.View;
using UnityEngine;

namespace App.Scripts.Game.Unit
{
  public class GameUnit : MonoBehaviour
  {
    [field: SerializeField] public GameUnitView View { get; private set; }

    public Health Health { get; private set; }
    public GameUnit Target { get; private set; }
    public UnitTeam Team { get; private set; }

    public bool IsAlive => Health.Value > 0;


    public void Construct(UnitTeam team)
    {
      Team = team;
      Target = null;
      Health = new Health();
    }

    public void SetTarget(GameUnit target)
    {
      Target = target;
    }
  }
}