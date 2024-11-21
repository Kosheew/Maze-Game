using SO_Settings.Character_Settings;
using UnityEngine;

namespace CharacterSettings
{
    [CreateAssetMenu(fileName = "Character Settings", menuName = "Character Settings/Create Enemy Settings")]
    public class EnemySetting: CharacterSetting
    {
        [SerializeField] private float chaseDistance;
        [SerializeField] private float attackDistance;
        [SerializeField] private float attackCooldown;
        public float ChaseDistance => chaseDistance;
        public float AttackDistance => attackDistance;
        public float AttackCooldown => attackCooldown;
    }
}