using UnityEngine;

namespace CharacterSettings.StateSettings
{
    public abstract class StateSetting : ScriptableObject
    {
        [SerializeField] private TypeCharacterStates typeCharacterStates;

        public TypeCharacterStates TypeCharacterStates => typeCharacterStates;
    }
}