using App.Scripts.Infrastructure.UI.Data;

namespace App.Scripts.Infrastructure.UI.ScreenService
{
  internal interface IScreenService
  {
    BaseScreen OpenScreen(ScreenType screenType);
  }
}