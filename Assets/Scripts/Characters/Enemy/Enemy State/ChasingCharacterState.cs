using Character;

namespace Enemy.State
{
    public class ChasingCharacterState : ICharacterState
    {
        public void EnterState(ICharacter character)
        {
            /*character.SetAnimation("Run", true);
            character.ResumeMovement();*/
        }
        
        public void UpdateState(ICharacter character)
        {
            /*if (!character.IsPlayerInChaseRange())
            {
                character.SwitchState(character.PatrollingCharacterState);
            }
            else if (character.IsPlayerInAttackRange())
            {
                character.SwitchState(character.AttackingCharacterState);
            }
            else
            {
                character.SetChaseDestination();
            }*/
        }

        public void ExitState(ICharacter character)
        {
            
        }
    }
}
