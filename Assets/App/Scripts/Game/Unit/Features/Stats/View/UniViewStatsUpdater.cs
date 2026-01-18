using System.Collections.Generic;
using System.Linq;
using App.Scripts.Game.Factory;
using App.Scripts.Infrastructure.Camera;
using App.Scripts.Infrastructure.UI.Factory;
using App.Scripts.Utils;
using App.Scripts.Utils.Extensions;
using UnityEngine;
using Zenject;

namespace App.Scripts.Game.Unit.Features.Stats.View
{
  public class UniViewStatsUpdater : ILateTickable
  {
    private readonly ICameraService _cameraService;
    private readonly IUIFactory _uiFactory;
    private readonly List<UnitViewStats> _unitStats = new List<UnitViewStats>();

    public UniViewStatsUpdater(ICameraService cameraService, IUIFactory uiFactory)
    {
      _cameraService = cameraService;
      _uiFactory = uiFactory;
    }

    public void AddUnitStats(UnitViewStats unitStats)
    {
      _unitStats.Add(unitStats);
      unitStats.Unit.Health.OnHealthChanged += UpdateHealthValue;
    }

    public void DestroyUnitStats(GameUnit unit)
    {
      foreach (var healthView in _unitStats.ToList().Where(healthView => healthView.Unit == unit))
      {
        _unitStats.Remove(healthView);
        _uiFactory.DestroyUnitStats(healthView);
      }
    }

    public void LateTick()
    {
      foreach (var healthView in _unitStats)
        UpdateUnitsStatsPosition(healthView);
    }

    private void UpdateHealthValue()
    {
      foreach (var unitStats in _unitStats)
      {
        var fillAmount = Mathematics.Remap(0, unitStats.Unit.Health.MaxValue, 0, 1, unitStats.Unit.Health.Value);

        unitStats.HealthView.Text.text = unitStats.Unit.Health.ToString();
        unitStats.HealthView.Fill.fillAmount = fillAmount;
      }
    }

    private void UpdateUnitsStatsPosition(UnitViewStats unitStats)
    {
      if (unitStats.Unit.IsAlive == false)
      {
        unitStats.CanvasGroup.alpha = 0f;
        return;
      }

      var height = unitStats.Unit.View.Height;
      var position = unitStats.Unit.transform.position.AddY(height);
      var screenPoint = _cameraService.Camera.WorldToScreenPoint(position);
      var viewportPoint = _cameraService.Camera.WorldToViewportPoint(position);
      unitStats.transform.position = screenPoint.SetZ(0f);
      unitStats.CanvasGroup.alpha += _cameraService.IsOnScreen(viewportPoint)
        ? Time.deltaTime * 1f : Time.deltaTime * -1f;
    }
  }
}