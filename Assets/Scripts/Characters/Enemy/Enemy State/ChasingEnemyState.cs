using Characters;
using Characters.Enemy;
using Commands;
using UnityEngine.AI;
using UnityEngine;

namespace Enemy.State
{
    public class ChasingEnemyState : BaseEnemyState
    {
        public override void EnterState(IEnemy enemy)
        {
            enemy.Agent.isStopped = false;
        }

        public override void UpdateState(IEnemy enemy)
        {
            if (!IsTargetInRange(enemy, enemy.CurrentTarget, enemy.EnemySetting.ChaseDistance))
            {
                enemy.CommandEnemy.CreatePatrolledCommand(enemy);
                return;
            }
            
            if (IsTargetInRange(enemy, enemy.CurrentTarget, enemy.EnemySetting.AttackDistance))
            {
                enemy.CommandEnemy.CreateAttackCommand(enemy);
                return;
            }
            
            enemy.CharacterAnimator.Running(enemy.Agent.velocity.magnitude);
            enemy.FootstepHandler.PlayFootstepSound();
            enemy.Agent.SetDestination(enemy.CurrentTarget.position);


        }

        public override void ExitState(IEnemy enemy)
        {
            enemy.Agent.isStopped = true;
            enemy.CharacterAnimator.Running(0);
        }
    }
}

