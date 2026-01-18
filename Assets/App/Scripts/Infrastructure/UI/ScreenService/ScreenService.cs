using System.Collections.Generic;
using App.Scripts.Infrastructure.UI.Data;
using App.Scripts.Infrastructure.UI.Factory;

namespace App.Scripts.Infrastructure.UI.ScreenService
{
  public class ScreenService : IScreenService
  {
    private BaseScreen _currentScreen;

    private readonly Dictionary<ScreenType, BaseScreen> _screensCache = new Dictionary<ScreenType, BaseScreen>();
    private readonly IUIFactory _uiFactory;

    public ScreenService(IUIFactory uiFactory)
    {
      _uiFactory = uiFactory;
    }

    public BaseScreen OpenScreen(ScreenType screenType)
    {
      if (_currentScreen != null)
        _currentScreen.Hide();

      if (_screensCache.TryGetValue(screenType, out var screen))
      {
        screen.Show();
        _currentScreen = screen;
        return screen;
      }

      _currentScreen = _uiFactory.CreateScreen(screenType);
      _screensCache.Add(screenType, _currentScreen);
      _currentScreen.Show();

      return _currentScreen;
    }
  }
}