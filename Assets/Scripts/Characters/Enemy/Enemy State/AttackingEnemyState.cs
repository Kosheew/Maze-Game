using Character;
using Character.Enemy;


namespace Enemy.State
{

    public class AttackingEnemyState : IEnemyState
    {

        public void EnterState(IEnemy enemy)
        {
            /*enemy.SetAnimation("Run", false);
            enemy.AttackPlayer();*/
        }
        
        public void UpdateState(IEnemy enemy)
        {
            /*if (!enemy.IsPlayerInAttackRange())
            {
                enemy.SwitchState(enemy.ChasingCharacterState);
            }*/
        }

        public void ExitState(IEnemy enemy)
        {
            
        }
    }
}
