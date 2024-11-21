using Characters;
using Characters.Enemy;
using UnityEngine;

namespace Enemy.State
{

    public class AttackingEnemyState : IEnemyState
    {

        public void EnterState(IEnemy enemy)
        {
            enemy.Agent.isStopped = true;
            enemy.Agent.velocity = Vector2.zero;
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
