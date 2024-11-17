using Character;

namespace Enemy.State
{

    public class AttackingCharacterState : ICharacterState
    {

        public void EnterState(ICharacter character)
        {
            /*enemy.SetAnimation("Run", false);
            enemy.AttackPlayer();*/
        }
        
        public void UpdateState(ICharacter character)
        {
            /*if (!enemy.IsPlayerInAttackRange())
            {
                enemy.SwitchState(enemy.ChasingCharacterState);
            }*/
        }

        public void ExitState(ICharacter character)
        {
            
        }
    }
}
