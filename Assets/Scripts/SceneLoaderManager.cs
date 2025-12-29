using Assets.Scripts.Architecture;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    internal class SceneLoaderManager : SingletonInstance<SceneLoaderManager>
    {
        [Header("Optional Loading UI")]
        public GameObject loadingRoot;
        public Slider loadingBar;

        public void LoadSceneAsync(string sceneName)
        {
            StartCoroutine(LoadRoutine(sceneName));
        }

        IEnumerator LoadRoutine(string sceneName)
        {
            if (loadingRoot != null) loadingRoot.SetActive(true);

            var op = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            op.allowSceneActivation = true;

            while (!op.isDone)
            {
                // progress zwykle dochodzi do ~0.9 zanim aktywuje scenę
                float p = Mathf.Clamp01(op.progress / 0.9f);
                if (loadingBar != null) loadingBar.value = p;
                yield return null;
            }

            if (loadingRoot != null) loadingRoot.SetActive(false);
        }

        public void LoadCreditsScene()
        {
            TimerManager.Instance.stopped = true;
            GameManager.Instance.CalculateAccuracy();

            Debug.Log("Loading Credits Scene");
            SceneManager.UnloadSceneAsync("GameScene");
            LoadSceneAsync("CreditsScene");
        }

        public void LoadMenu() => LoadSceneAsync("MenuScene");
        public void LoadGame()
        {
            //OnStartGame();
            SceneManager.UnloadSceneAsync("MenuScene");
            LoadSceneAsync("GameScene");
        }

        private void OnStartGame()
        {
            TimerManager.Instance.stopped = false;
            TimerManager.Instance.ellapsedTime = 0;
            MusicManager.Instance.PlayMusic();
        }

        public void RestartGame()
        {
            OnStartGame();
            SceneManager.UnloadSceneAsync("CreditsScene");
            LoadSceneAsync("GameScene");
        }

        public void QuitGame()
        {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
        }
    }
}
