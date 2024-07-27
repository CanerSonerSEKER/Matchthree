using Events;
using Utils;

namespace Components.UI.MainMenu.SettingsPanel
{
    public class SettingsExitBTN : UIBTN
    {
        protected override void OnClick()
        {
            MainMenuEvents.SettingsExitBTN?.Invoke();
        }
    }
}