
using Assets.Scripts.Architecture;

namespace Assets.Scripts.Targets
{
    internal class TargetsManager : SingletonInstance<TargetsManager>
    {
        public int visibleTargetsCount = 8;

        private void Update()
        {
            if(visibleTargetsCount <= 0)
            {
                SceneLoaderManager.Instance.LoadCreditsScene();
            }
        }
    }
}
