using Events;
using Utils;

namespace Components.UI.MainMenu
{
    public class AboutExitBTN : UIBTN
    {
        protected override void OnClick()
        {
            MainMenuEvents.AboutExitBTN?.Invoke();
        }
    }
}