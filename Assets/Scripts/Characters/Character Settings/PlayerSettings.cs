using UnityEngine;

namespace Character.Character_Settings
{
    [CreateAssetMenu(fileName = "Character Settings", menuName = "Create Player Settings")]
    public class PlayerSettings: CharacterSettings
    {
        [SerializeField] private float maxClamp;
        [SerializeField] private float accelerationRate;
        
        public float MaxClamp => maxClamp;
        public float AccelerationRate => accelerationRate;
    }
}