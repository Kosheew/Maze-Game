using UnityEngine;

namespace Character
{
    public class FootstepHandler : IFootstepHandler
    {
        private readonly AudioSource _audioSource;       
        private readonly AudioClip[] _footstepClips;    
        private readonly float _stepInterval;  
        private float _nextStep = 0f; 
        
        public FootstepHandler(AudioSource audioSource, AudioSettings audioSettings)
        {
            _audioSource = audioSource;
            _footstepClips = audioSettings.StepAudioClips;
            _stepInterval = audioSettings.StepInterval;
        }
        
        public void PlayFootstepSound()
        {
            if (!(Time.time >= _nextStep)) return;
            var clip = GetRandomFootstepClip(); 
            _audioSource.PlayOneShot(clip);        
            _nextStep = Time.time + _stepInterval;   
        }
        
        private AudioClip GetRandomFootstepClip()
        {
            var index = Random.Range(0, _footstepClips.Length); 
            return _footstepClips[index];                       
        }
    }
}
