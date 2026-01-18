using App.Scripts.Game.Unit;
using App.Scripts.Game.Unit.Configs;
using App.Scripts.Game.Unit.Features.Characteristics;
using App.Scripts.Game.Unit.Features.Stats.Data;
using App.Scripts.Infrastructure.Camera;
using App.Scripts.Infrastructure.StaticData;
using App.Scripts.Utils;
using App.Scripts.Utils.Extensions;
using UnityEngine;

namespace App.Scripts.Game.Explosion
{
  public class ExplosionService
  {
    private readonly GameModel _gameModel;
    private readonly ICameraService _cameraService;
    private readonly IStaticDataService _staticData;
    private readonly UnitCharacteristicsApplier _characteristicsApplier;

    public ExplosionService(GameModel gameModel, ICameraService cameraService, IStaticDataService staticData,
      UnitCharacteristicsApplier characteristicsApplier)
    {
      _gameModel = gameModel;
      _cameraService = cameraService;
      _staticData = staticData;
      _characteristicsApplier = characteristicsApplier;
    }

    public void Tick()
    {
      if (!Input.GetMouseButtonDown(0))
        return;

      var ray = _cameraService.Camera.ScreenPointToRay(Input.mousePosition);

      if (!Physics.Raycast(ray, out var hit))
        return;

      var explosionPosition = hit.point;
      Explode(explosionPosition);
    }

    private void Explode(Vector3 position)
    {
      var explosionConfig = _staticData.ExplosionConfig;
      var randomColor = EnumExtensions.GetRandom<UnitColor>();

      foreach (var unit in _gameModel.AllUnits)
      {
        if (!unit.IsAlive)
          continue;

        var directionAway = (unit.transform.position - position).SetY(0f);
        if (directionAway.magnitude <= explosionConfig.Radius)
        {
          ApplyPushForce(unit, directionAway.normalized * explosionConfig.PushForce);
          ChangeUnitColor(unit, randomColor);
        }
      }
    }

    private void ChangeUnitColor(GameUnit unit, UnitColor newColor)
    {
      if (unit.CurrentStats.Color == newColor)
        return;

      _characteristicsApplier.ReconfigureWithNewColor(unit, newColor);

      if (_staticData.UnitViewConfig.Materials.TryGetValue(newColor, out var material))
      {
        var currentSize = Vector3.one * _staticData.UnitViewConfig.Scales[unit.CurrentStats.Size];
        unit.View.UpdateColorAndSize(material, currentSize);
      }

      var newStats = unit.CurrentStats;
      newStats.Color = newColor;
      unit.SetStats(newStats);
    }

    private void ApplyPushForce(GameUnit unit, Vector3 pushVelocity)
    {
      unit.MovementData.Direction = pushVelocity.normalized;
      unit.MovementData.CurrentSpeed = pushVelocity.magnitude;
    }
  }
}