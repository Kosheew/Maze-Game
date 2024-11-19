using UnityEngine;

namespace Characters
{
    public class FootstepHandler : IFootstepHandler
    {
        private readonly AudioSource _audioSource;
        private readonly CharacterAudioSettings _characterAudioSettings;
        private float _nextStep = 0;
        
        public FootstepHandler(AudioSource audioSource, CharacterAudioSettings characterAudioSettings)
        {
            _audioSource = audioSource;
            _characterAudioSettings = characterAudioSettings;
        }
        
        public void PlayFootstepSound()
        {
            if (!(Time.time >= _nextStep)) return;
            var clip = _characterAudioSettings.GetRandomFootstepClip();
            _audioSource.PlayOneShot(clip);        
            _nextStep = Time.time + _characterAudioSettings.StepInterval;   
        }
        
        
    }
}
