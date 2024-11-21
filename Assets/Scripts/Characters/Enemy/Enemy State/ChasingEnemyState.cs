using Characters;
using Characters.Enemy;
using Commands;
using UnityEngine.AI;
using UnityEngine;

namespace Enemy.State
{
    public class ChasingEnemyState : IEnemyState
    {
        private NavMeshAgent _agent;
        private CharacterAnimator _characterAnimator;
        private CommandEnemyFactory _commandEnemy;
        
        public void EnterState(IEnemy enemy)
        {
            _agent = enemy.Agent;
            _characterAnimator = enemy.CharacterAnimator;
            _commandEnemy = enemy.CommandEnemy;
        }
        
        // ReSharper disable Unity.PerformanceAnalysis
        public void UpdateState(IEnemy enemy)
        {
            _agent.SetDestination(enemy.CurrentTarget.transform.position);
            _characterAnimator.Running(_agent.velocity.magnitude);
            
            if (Vector3.Distance(enemy.MainPosition.position, enemy.CurrentTarget.position) < 2 && enemy.CurrentTarget)
            {
                _commandEnemy.CreateAttackCommand(enemy);
            }
            else if (Vector3.Distance(enemy.MainPosition.position, enemy.CurrentTarget.position) > 10 )
            {
                _commandEnemy.CreatePatrolledCommand(enemy);
            }
        }

        public void ExitState(IEnemy enemy)
        {
            _characterAnimator.Running(_agent.velocity.magnitude);
        }
    }
}
