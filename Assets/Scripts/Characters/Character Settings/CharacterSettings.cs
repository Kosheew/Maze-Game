using UnityEngine;

namespace Character.Character_Settings
{
    public abstract class CharacterSettings: ScriptableObject
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float turnSpeed;
        [SerializeField] private ICharacterState[] characterState;
        
        public float MoveSpeed => moveSpeed;
        public float TurnSpeed => turnSpeed;
    }
}