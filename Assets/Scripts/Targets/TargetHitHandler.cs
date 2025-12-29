using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Targets
{
    internal class TargetHitHandler : MonoBehaviour
    {
        public string name;
        public TargetVisualController visual;
        public TargetBehaviourController behaviour;
        public TargetSimpleMoveSystem moveSystem;
        public Collider2D collider;

        public void OnGetHit()
        {
            GameManager.Instance.targetsHit.Add(name);

            if (moveSystem != null) moveSystem.enabled = false;
            if (behaviour != null)  behaviour.enabled = false;
            if(collider != null) collider.enabled = false;

            behaviour.reactionHandler.HideReaction();
            visual.PlayAnimation("die");
            var removed = TargetsManager.Instance.targetsOnArea.Remove(name);
            Debug.Log("C1 Target " + name + " hit. Removed from area: " + removed + $"TargetsManager.Instance.targetsOnArea: {TargetsManager.Instance.targetsOnArea.Count}");

            //visual.OnAnimationBehaviourEnds += OnPlayerDied;
        }

        //private void OnPlayerDied()
        //{
        //    StartCoroutine(EndGameCoroutine());
        //}

        //private IEnumerator EndGameCoroutine()
        //{
        //    yield return new WaitForSeconds(1.5f);
        //    SceneLoaderManager.Instance.LoadCreditsScene();
        //}
    }
}
