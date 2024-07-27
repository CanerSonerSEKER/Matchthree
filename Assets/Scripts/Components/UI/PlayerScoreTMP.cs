using System;
using DG.Tweening;
using Events;
using Extensions.DoTween;
using Extensions.Unity.MonoHelper;
using TMPro;
using UnityEngine;
using Zenject;

namespace Components.UI
{
    public class PlayerScoreTMP : UITMP, ITweenContainerBind
    {
        [Inject] private GridEvents GridEvents {get; set; }
        public ITweenContainer TweenContainer { get; set; }
        private Tween _counterTween;
        private int _currCounterVal;
        private int _playerScore;

        [SerializeField] private TextMeshProUGUI highScoreText;
        
        [SerializeField] private TextMeshProUGUI timerText;
        private float _totalTime;

        private void Awake()
        {
            TweenContainer = TweenContain.Install(this);
            UpdateHighScoreText();
        }

        private void Update()
        {
            _totalTime = EnvVar.totalTime;
            
            if (_totalTime > 0)
            {
                _totalTime -= Time.deltaTime;

                float minutes = Mathf.FloorToInt(_totalTime / 60);

                float seconds = Mathf.FloorToInt(_totalTime % 60);

                timerText.text = string.Format("Time : {0:00}:{1:00}", minutes, seconds);
            }
            else
            {
                Debug.LogWarning($"Time's up!");
                _totalTime = 0;
                // GameOver fonksiyonu gibi bir şeyler.
            }
        }

        protected override void RegisterEvents()
        {
            GridEvents.MatchGroupDespawn += OnMatchGroupDespawn;
        }

        private void OnMatchGroupDespawn(int arg0)
        {
            _playerScore += arg0;

            if (_counterTween.IsActive()) _counterTween.Kill();
            
            _counterTween = DOVirtual.Int
            (_currCounterVal,
                _playerScore,
                1f,
                OnCounterUpdate
            );
            TweenContainer.AddTween = _counterTween;
            CheckHighScore();
        }

        private void CheckHighScore()
        {
            if (_playerScore > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", _playerScore);
            }
            UpdateHighScoreText();
        }

        private void OnCounterUpdate(int val)
        {
            _currCounterVal = val;
            _myTMP.text = $"Score: {_currCounterVal}";
        }

        protected override void UnRegisterEvents()
        {
            GridEvents.MatchGroupDespawn -= OnMatchGroupDespawn;
        }

        void UpdateHighScoreText()
        {
            highScoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
        }

    }
}
