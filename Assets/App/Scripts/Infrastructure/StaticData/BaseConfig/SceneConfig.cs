using System;
using App.Scripts.Game.Unit.Features.Spawn.Zone;
using UnityEngine;

namespace App.Scripts.Infrastructure.StaticData.BaseConfig
{
  [Serializable]
  public class SceneConfig
  {
    public SpawnZone FirstTeamZone;
    public SpawnZone SecondTeamZone;
    public Transform ScreensParent;
    public Transform EnemiesParent;
    public Transform HealthViewsParent;
  }
}