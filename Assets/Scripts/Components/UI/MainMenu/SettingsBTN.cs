using Events;
using Utils;

namespace Components.UI.MainMenu
{
    public class SettingsBTN : UIBTN
    {
        protected override void OnClick()
        {
            MainMenuEvents.SettingsBTN?.Invoke();
        }
    }
}