using InitGame.Audio;
using UnityEngine;

namespace Enemy.Command
{
    /// <summary>
    /// Command to trigger an attack animation on an enemy.
    /// </summary>
    public class AttackCommand : ICommand
    {
        private Animator _animator;
        private AudioClip _attackSound; // Sound for attack
        private AudioSource _audioManager; 

        /// <summary>
        /// Initializes a new instance of the <see cref="AttackCommand"/> class.
        /// </summary>
        /// <param name="animator">The animator component responsible for controlling animations.</param>
        public AttackCommand(Animator animator, AudioClip attackSound, AudioSource audioManager)
        {
            _animator = animator;
            _attackSound = attackSound; // Assign the attack sound
            _audioManager = audioManager; // Assign the AudioManager
        }

        /// <summary>
        /// Executes the attack command by setting the attack trigger on the animator.
        /// </summary>
        public void Execute()
        {
            _animator.SetTrigger("Attack");
            _audioManager.PlayOneShot(_attackSound);
        }
    }
}
