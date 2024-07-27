using Events;
using Utils;

namespace Components.UI.MainMenu
{
    public class AboutBTN : UIBTN
    {
        protected override void OnClick()
        {
            MainMenuEvents.AboutBTN?.Invoke();
        }
    }
}