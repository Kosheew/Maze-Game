using System.Collections.Generic;
using Character;

public class StateManager
{
    private Dictionary<ICharacter, ICharacterState> _states = new();
    
    public ICharacterState CurrentState { get; private set; }
    
    public void SetState(ICharacterState newState, ICharacter character)
    {
        if (_states.ContainsKey(character))
        {
            _states[character].ExitState(character);
        }

        _states[character] = newState;
        newState.EnterState(character);
    }
    
    public void UpdateState(ICharacter character)
    {
        if (_states.TryGetValue(character, out var state))
        {
            state.UpdateState(character);
        }
    }
    
}
