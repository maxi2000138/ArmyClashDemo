using System;
using UnityEngine;

namespace App.Scripts.Game.Field.Configs
{
  [Serializable]
  public class FieldConfig
  {
    public SpawnZone FirstTeam;
    public SpawnZone SecondTeam;
    public Transform EnemiesParent;
  }
}