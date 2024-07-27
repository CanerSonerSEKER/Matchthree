using Events;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Components.UI.AudioSettings
{
    public class SoundSlider : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [Inject] private AudioEvents AudioEvents { get; set; }
        private void Awake()
        {
            if (_slider == null)
            {
                _slider = GetComponent<Slider>();
            }
        }

        private void OnEnable()
        {
            _slider.value = PlayerPrefs.GetFloat("SoundVolume", 1f);
            _slider.onValueChanged.AddListener(OnSliderValueChanged);
        }

        private void OnDisable()
        {
            _slider.onValueChanged.RemoveListener(OnSliderValueChanged);
        }

        private void OnSliderValueChanged(float value)
        {
            AudioEvents.VolumeChanged?.Invoke(value);
        }
    }
}