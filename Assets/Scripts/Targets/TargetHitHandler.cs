using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Targets
{
    internal class TargetHitHandler : MonoBehaviour
    {
        public string name;
        public TargetVisualController visual;
        public TargetBehaviourController behaviour;
        public TargetSimpleMoveSystem moveSystem;

        public void OnMouseDown()
        {
            if (GameManager.Instance.targetName == name)
            {
                GameManager.Instance.gameResult = GameResult.PlayerWon;
            }
            else
            {
                GameManager.Instance.gameResult = GameResult.WrongTargetHit;
            }


            if (moveSystem != null) moveSystem.enabled = false;
            if (behaviour != null)  behaviour.enabled = false;

            TimerManager.Instance.stopped = true;
            visual.PlayAnimation("die");
            visual.OnAnimationBehaviourEnds += OnPlayerDied;
        }

        private void OnPlayerDied()
        {
            StartCoroutine(EndGameCoroutine());
        }

        private IEnumerator EndGameCoroutine()
        {
            yield return new WaitForSeconds(1.5f);
            SceneLoaderManager.Instance.LoadCreditsScene();
        }
    }
}
