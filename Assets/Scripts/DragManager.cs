using Assets.Scripts.Architecture;
using UnityEngine;

namespace Assets.Scripts
{
    class DragManager : SingletonInstance<DragManager>
    {
        public AudioSource dragSoundSource;

        public void PlayDragSound()
        {
            var pitch = Random.Range(0.8f, 1.2f);
            dragSoundSource.pitch = pitch;
            dragSoundSource.Play();
        }
    }
}
