using Characters;
using Characters.Enemy;


namespace Enemy.State
{
    public class ChasingEnemyState : IEnemyState
    {
        public void EnterState(IEnemy enemy)
        {
            /*character.SetAnimation("Run", true);
            character.ResumeMovement();*/
        }
        
        public void UpdateState(IEnemy enemy)
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

        public void ExitState(IEnemy enemy)
        {
            
        }
    }
}
