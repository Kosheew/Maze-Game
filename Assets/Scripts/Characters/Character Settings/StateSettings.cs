using UnityEngine;

public abstract class StateSettings : ScriptableObject
{
    [SerializeField] private TypeCharacterStates typeCharacterStates;
    
    public TypeCharacterStates TypeCharacterStates => typeCharacterStates; 
}
