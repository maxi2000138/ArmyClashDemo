using App.Scripts.Game.Unit.Features.Attack;
using App.Scripts.Game.Unit.Features.Characteristics;
using App.Scripts.Game.Unit.Features.Health;
using App.Scripts.Game.Unit.Features.Stats;
using App.Scripts.Game.Unit.Features.Stats.Data;
using App.Scripts.Game.Unit.View;
using UnityEngine;

namespace App.Scripts.Game.Unit
{
  public class GameUnit : MonoBehaviour
  {
    [field: SerializeField] public GameUnitView View { get; private set; }

    public Health Health { get; private set; }
    public AttackData AttackData { get; private set; }
    public UnitCharacteristics Characteristics { get; private set; }
    public GameUnit Target { get; private set; }
    public UnitTeam Team { get; private set; }
    public Vector3 CurrentDirection { get; set; }

    public bool IsAlive => Health.Value > 0;


    public void Construct(UnitTeam team, float baseHp, float baseAtk, float baseSpeed, float baseAtkSpd)
    {
      Team = team;
      Target = null;
      CurrentDirection = Vector3.zero;
      Health = new Health();
      AttackData = new AttackData();
      Characteristics = new UnitCharacteristics(baseHp, baseAtk, baseSpeed, baseAtkSpd);
    }

    public void SetTarget(GameUnit target)
    {
      Target = target;
    }
  }
}