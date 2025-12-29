
using Assets.Scripts.Architecture;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Targets
{
    internal class TargetsManager : SingletonInstance<TargetsManager>
    {
        private bool finished = false;

        public HashSet<string> targetsOnArea;

        private void Start()
        {
            targetsOnArea = new HashSet<string>(GameManager.Instance.avaialableTargets);
        }

        private void Update()
        {
            var targetsLeft = targetsOnArea.Aggregate("", (acc, curr) => acc + " " + curr);
            Debug.Log("Targets remaining: " + targetsOnArea.Count + " " + targetsLeft);

            if (targetsOnArea.Count <= 0)
            {
                if(finished) return;

                StartCoroutine(LoadCreditsCoroutine());
            }
        }

        private IEnumerator LoadCreditsCoroutine()
        {
            finished = true;
            yield return new WaitForSeconds(2f);
            SceneLoaderManager.Instance.LoadCreditsScene();
        }
    }
}
