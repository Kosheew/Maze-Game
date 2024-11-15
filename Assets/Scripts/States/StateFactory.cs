using System;
using Character;
using Enemy.State;

public class StateFactory 
{
    public ICharacterState CreateState(TypeCharacterStates stateName)
    {
        return stateName switch
        {
            TypeCharacterStates.Attacked => new AttackingCharacterState(),
            TypeCharacterStates.Chased => new ChasingCharacterState(),
            TypeCharacterStates.Patrolled => new PatrollingCharacterState(),
            TypeCharacterStates.Idle => new IdleCharacterState(),
            _ => throw new ArgumentException($"Unknown state: {stateName}")
        };
    }
}
