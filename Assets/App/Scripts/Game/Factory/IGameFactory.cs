using App.Scripts.Game.Unit;
using App.Scripts.Game.Unit.Features.Stats;
using App.Scripts.Game.Unit.Features.Stats.Data;
using UnityEngine;

namespace App.Scripts.Game.Factory
{
  public interface IGameFactory
  {
    GameUnit CreateUnit(UnitStats stats, UnitTeam team, Vector3 at);
    void RemoveUnit(GameUnit unit);
  }
}