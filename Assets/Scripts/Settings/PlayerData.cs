//
using Events;
using UnityEngine;
using Zenject;

namespace Settings
{
    public class PlayerData : IInitializable
    {
        [Inject] private AudioEvents AudioEvents { get; set; } 
        private const string SoundPrefKey = "Sound";
        public float SoundVal => _soundVal;
        private float _soundVal;

        public PlayerData()
        {
            _soundVal = PlayerPrefs.GetFloat(SoundPrefKey);
        }

        private void RegisterEvents()
        {
            AudioEvents.VolumeChanged += OnVolumeChanged;
        }

        private void OnVolumeChanged(float soundVal)
        {
            _soundVal = soundVal;
            PlayerPrefs.SetFloat(SoundPrefKey, _soundVal);
        }

        public void Initialize()
        {
            RegisterEvents();
        }
    }
}


//