using InitGame.Audio;
using InitGame.Level;
using UnityEngine;

namespace GameKeys 
{
    
    public class Key : MonoBehaviour, ITouching
    {
        [SerializeField] private AudioClip _pickUpSound;
        private AudioManager _audioManager;
        private Wallet _wallet;
        
        public void Inject(DependencyContainer container)
        {
            _wallet = container.Resolve<Wallet>();
            _audioManager = container.Resolve<AudioManager>();
        }
        
        public void Touch()
        {           
            _wallet.AddKey();
            _audioManager.PlaySound(_pickUpSound);
            gameObject.SetActive(false); 
        }
    }
}
