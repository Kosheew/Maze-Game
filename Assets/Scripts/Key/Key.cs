using InitGame.Audio;
using UnityEngine;

namespace GameKeys 
{
    
    public class Key : MonoBehaviour, ITouching
    {
        [SerializeField] private AudioClip _pickUpSound;
        private AudioManager _audioManager;

        private void Start()
        {
          
        }
      
        public void Touch()
        {
           
            _audioManager.PlaySound(_pickUpSound);
            gameObject.SetActive(false); // Deactivate the key object to indicate it has been collected.
        }
    }
}
