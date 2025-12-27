using Assets.Scripts;
using Assets.Scripts.Architecture;

namespace Assets
{
    internal class MainMenuManager : SingletonInstance<MainMenuManager>
    {
        public void StartGame()
        {
            SceneLoaderManager.Instance.LoadGame();
        }
    }
}
