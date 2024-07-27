using Events;
using UnityEngine;
using EventListenerMono = Utils.EventListenerMono;

namespace Components.UI.MainMenu
{
    public class MainMenuManager : EventListenerMono
    {

        [SerializeField] private GameObject _mainMenuPanel;
        [SerializeField] private GameObject _settingsMenuPanel;
        [SerializeField] private GameObject _aboutMenuPanel;
        private void Start()
        {
            SetPanelActive(_mainMenuPanel);
        }

        private void SetPanelActive(GameObject panel)
        {
            _mainMenuPanel.SetActive(_mainMenuPanel == panel);    
            _settingsMenuPanel.SetActive(_settingsMenuPanel == panel);
            _aboutMenuPanel.SetActive(_aboutMenuPanel == panel);
        }

        protected override void RegisterEvents()
        {
            MainMenuEvents.SettingsBTN += OnSettingsBTN;
            MainMenuEvents.SettingsExitBTN += OnSettingsExitBTN;
            MainMenuEvents.AboutBTN += OnAboutBTN;
            MainMenuEvents.AboutExitBTN += OnAboutExitBTN;
        }

        private void OnAboutBTN()
        {
            SetPanelActive(_aboutMenuPanel);
        }

        private void OnAboutExitBTN()
        {
            SetPanelActive(_mainMenuPanel);
        }

        private void OnSettingsBTN()
        {
            SetPanelActive(_settingsMenuPanel);
        }
        
        private void OnSettingsExitBTN()
        {
            SetPanelActive(_mainMenuPanel);
        }

        protected override void UnRegisterEvents()
        {
            MainMenuEvents.SettingsBTN -= OnSettingsBTN;
            MainMenuEvents.SettingsExitBTN -= OnSettingsExitBTN;
            MainMenuEvents.AboutBTN -= OnAboutBTN;
            MainMenuEvents.AboutExitBTN -= OnAboutExitBTN;
        }
    }
}
