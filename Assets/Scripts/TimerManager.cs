using Assets.Scripts.Architecture;
using UnityEngine;

namespace Assets.Scripts
{
    internal class TimerManager : SingletonInstance<TimerManager>
    {
        public bool stopped = false;
        public float ellapsedTime = 0f;

        private void Start()
        {
            ellapsedTime = 0f;
        }

        private void Update()
        {
            if(stopped) return;

            ellapsedTime += Time.deltaTime;
        }
    }
}
