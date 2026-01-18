using System.Collections.Generic;
using App.Scripts.Infrastructure.UI.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Infrastructure.UI.Configs
{
  [CreateAssetMenu(fileName = nameof(ScreensConfig), menuName = "Configs/" + nameof(ScreensConfig), order = -1000)]
  public class ScreensConfig : SerializedScriptableObject
  {
    public Dictionary<ScreenType, BaseScreen> Screens;
  }
}