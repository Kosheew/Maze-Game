using UnityEngine;

namespace CharacterSettings.StateSettings
{
    [CreateAssetMenu(fileName = "Attack Settings", menuName = "State Settings/Attack State Settings")]
    public class AttackSetting: StateSetting
    {
        [SerializeField] private float attackDistance;
        public float AttackDistance => attackDistance;
    }
}