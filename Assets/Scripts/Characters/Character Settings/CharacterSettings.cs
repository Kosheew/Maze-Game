using UnityEngine;

namespace Character.Character_Settings
{
    public abstract class CharacterSettings: ScriptableObject
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float turnSpeed;
        [SerializeField] private StateSettings[] characterState;
        
        public float MoveSpeed => moveSpeed;
        public float TurnSpeed => turnSpeed;

        public StateSettings GetStateSettings(TypeCharacterStates type)
        {
            foreach (var element in characterState)
            {
                if(element.TypeCharacterStates.Equals(type))
                    return element;
            }
            return null;
        }
    }
}