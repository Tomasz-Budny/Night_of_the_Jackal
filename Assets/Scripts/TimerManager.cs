using Assets.Scripts.Architecture;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    internal class TimerManager : SingletonInstance<TimerManager>
    {
        public Image timerFillImage;
        public float maxTimeSeconds = 20f;

        private float _currentTime;
        public bool stopped = false;

        private void Start()
        {
            _currentTime = maxTimeSeconds;
        }

        private void Update()
        {
            if(stopped) return;

            _currentTime -= Time.deltaTime;
            var timeRatio = maxTimeSeconds;
            timerFillImage.fillAmount = _currentTime / timeRatio;

            if (_currentTime <= 0)
            {
                GameManager.Instance.gameResult = GameResult.Timeout;
                SceneLoaderManager.Instance.LoadCreditsScene();
            }
        }
    }
}
