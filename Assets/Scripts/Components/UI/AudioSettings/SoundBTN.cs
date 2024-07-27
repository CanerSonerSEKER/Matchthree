using System;
using Events;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Components.UI.AudioSettings
{
    public class SoundBTN : MonoBehaviour
    {
        [Inject] private AudioEvents AudioEvents { get; set; }
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(PlaySound);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(PlaySound);
        }

        private void PlaySound()
        {
            AudioEvents.ButtonClicked?.Invoke();
        }
    }
}