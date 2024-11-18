using UnityEngine;

namespace CharacterSettings.StateSettings
{
    [CreateAssetMenu(fileName = "Patrolling Settings", menuName = "State Settings/Patrolling State Settings")]
    public class PatrollingState: StateSetting
    {
        [SerializeField] private float destinationThreshold;
        
        public float DestinationThreshold => destinationThreshold;
    }
}