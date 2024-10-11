using UnityEngine;

namespace Player
{
    /// <summary>
    /// Handles the playback of footstep sounds for the player character.
    /// Implements the IFootstepHandler interface to provide footstep sound functionality.
    /// </summary>
    public class FootstepHandler : IFootstepHandler
    {
        private AudioSource _audioSource;        // The audio source component used for playing sounds.
        private AudioClip[] _footstepClips;      // Array of footstep audio clips to be played.
        private float _stepInterval = 0.5f;       // Time interval between footstep sounds.
        private float _nextStep = 0f;             // The time when the next footstep sound can be played.

        /// <summary>
        /// Initializes a new instance of the FootstepHandler class.
        /// </summary>
        /// <param name="audioSource">The AudioSource component for playing footstep sounds.</param>
        /// <param name="footstepClips">An array of audio clips for footstep sounds.</param>
        /// <param name="stepInterval">The time interval between footstep sounds.</param>
        public FootstepHandler(AudioSource audioSource, AudioClip[] footstepClips, float stepInterval)
        {
            _audioSource = audioSource;
            _footstepClips = footstepClips;
            _stepInterval = stepInterval;
        }

        /// <summary>
        /// Plays a footstep sound if the time since the last step exceeds the step interval.
        /// </summary>
        public void PlayFootstepSound()
        {
            if (Time.time >= _nextStep)
            {
                AudioClip clip = GetRandomFootstepClip(); // Get a random footstep sound clip
                _audioSource.PlayOneShot(clip);           // Play the selected footstep sound
                _nextStep = Time.time + _stepInterval;    // Schedule the next footstep sound
            }
        }

        /// <summary>
        /// Selects a random footstep audio clip from the array.
        /// </summary>
        /// <returns>A randomly selected AudioClip from the footstepClips array.</returns>
        private AudioClip GetRandomFootstepClip()
        {
            int index = Random.Range(0, _footstepClips.Length); // Get a random index
            return _footstepClips[index];                        // Return the audio clip at the random index
        }
    }
}
