using UnityEngine;
using CharacterSettings.StateSettings;

namespace CharacterSettings
{
    public abstract class CharacterSetting: ScriptableObject
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float turnSpeed;
        
        [SerializeField] private CharacterAudioSettings characterAudioSettings;
        
        [SerializeField] private ScriptableObject[] characterState;
        
        public float MoveSpeed => moveSpeed;
        public float TurnSpeed => turnSpeed;

        public CharacterAudioSettings CharacterAudioSettings => characterAudioSettings;
        
        /*public object GetStateSettings(TypeCharacterStates type)
        {
            foreach (var element in characterState)
            {
                if(element.TypeCharacterStates.Equals(type))
                    return element;
            }
            return null;
        }*/
    }
}