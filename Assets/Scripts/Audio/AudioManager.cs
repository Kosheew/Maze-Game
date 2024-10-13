using UnityEngine;

namespace InitGame.Audio
{
    public class AudioManager : MonoBehaviour, IService
    {
        private AudioSource _audioSource; 

        public void Init()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlaySound(AudioClip clip)
        {
            if (clip != null && _audioSource != null)
            {
                _audioSource.PlayOneShot(clip); // Play the sound
            }
        }
    }
}