using SO_Settings.Character_Settings;
using UnityEngine;

namespace CharacterSettings
{
    [CreateAssetMenu(fileName = "Character Settings", menuName = "Character Settings/Create Enemy Settings")]
    public class EnemySetting: CharacterSetting
    {
        [SerializeField] private float chaseDistance;
        public float ChaseDistance => chaseDistance;
    }
}