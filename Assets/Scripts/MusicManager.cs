using Assets.Scripts.Architecture;
using UnityEngine;

namespace Assets.Scripts
{
    internal class MusicManager : SingletonInstance<MusicManager>
    {
        public AudioSource musicSource;
        public AudioSource panicSource;

        public void PlayMusic()
        {
            musicSource.Play();
        }

        public void StopMusic()
        {
            musicSource.Stop();
        }

        public void PlayPanicMusic()
        {
            panicSource.Play();
        }
    }
}
