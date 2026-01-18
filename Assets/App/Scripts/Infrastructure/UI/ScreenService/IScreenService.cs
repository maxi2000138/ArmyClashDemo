using App.Scripts.Infrastructure.UI.Data;

namespace App.Scripts.Infrastructure.UI.ScreenService
{
  public interface IScreenService
  {
    BaseScreen OpenScreen(ScreenType screenType);
  }
}