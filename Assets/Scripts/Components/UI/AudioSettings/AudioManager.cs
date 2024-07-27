using Events;
using UnityEngine;
using Utils;
using Zenject;

namespace Components.UI.AudioSettings
{
    public class AudioManager : EventListenerMono
    {
        [Inject] private AudioEvents AudioEvents { get; set; }
        [Inject] private GridEvents GridEvents { get; set; }
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _sfxSource;
        [SerializeField] private AudioClip _buttonClickSound;
        [SerializeField] private AudioClip _tileDestroyedSound;
        [SerializeField] private AudioClip _tileSlideSound;
        [SerializeField] private AudioClip _tileBombSound;

        protected override void RegisterEvents()
        {
            AudioEvents.VolumeChanged += OnVolumeChanged;
            AudioEvents.ButtonClicked += OnButtonClicked;
           // AudioEvents.TileDestroyed += OnTileDestroyed;
            AudioEvents.TileSlided += OnTileSlided;
            AudioEvents.TileBombed += OnTileBombed;
            GridEvents.MatchGroupDespawn += OnMatchGroupDespawn;
            OnVolumeChanged(PlayerPrefs.GetFloat("Sound Volume", 1f));
        }

        private void OnMatchGroupDespawn(int arg0)
        {
            OnTileDestroyed();
        }

        protected override void UnRegisterEvents()
        {
            AudioEvents.VolumeChanged -= OnVolumeChanged;
            AudioEvents.ButtonClicked -= OnButtonClicked;
            //AudioEvents.TileDestroyed -= OnTileDestroyed;
            AudioEvents.TileSlided -= OnTileSlided;
            AudioEvents.TileBombed -= OnTileBombed;
            GridEvents.MatchGroupDespawn -= OnMatchGroupDespawn;
        }

        private void Start()
        {
            OnVolumeChanged(PlayerPrefs.GetFloat("Sound Volume", 1f));
        }

        private void OnVolumeChanged(float volume)
        {
            if (_musicSource != null)
            {
                _musicSource.volume = volume;
            }

            if (_sfxSource != null)
            {
                _sfxSource.volume = volume;
            }

            PlayerPrefs.SetFloat("Sound Volume", volume);
            PlayerPrefs.Save();
        }

        private void OnButtonClicked()
        {
            Debug.LogWarning($"Buraya giriyor musun açık mısın kardeş: {_sfxSource?.enabled}");
            if (_sfxSource != null && _buttonClickSound)
            {
                Debug.LogWarning($"Button if statementın içerisinde demektir.");
                _sfxSource.PlayOneShot(_buttonClickSound);
            }
            else
            {
                Debug.LogWarning($"Buton if statementın içerisine girmemiş demektir.");
            }
        }

        private void OnTileDestroyed()
        {
            if (_sfxSource != null && _tileDestroyedSound != null)
            {
                _sfxSource.PlayOneShot(_tileDestroyedSound);
            }
        }

        private void OnTileSlided()
        {
            if (_sfxSource != null && _tileSlideSound != null)
            {
                _sfxSource.PlayOneShot(_tileSlideSound);
            }
        }

        private void OnTileBombed()
        {
            if (_sfxSource != null && _tileBombSound != null)
            {
                _sfxSource.PlayOneShot(_tileBombSound);
            }
            else
            {
                Debug.LogWarning($"Bombanın sesi sıkıntılı - OnTileBomb : {_tileBombSound}");
            }
        }

        private void PlayAudioClip(AudioClip clip)
        {
            _sfxSource.Stop();
            _sfxSource.clip = clip;
            _sfxSource.Play();
            _sfxSource.loop = false;
        }
    }
}