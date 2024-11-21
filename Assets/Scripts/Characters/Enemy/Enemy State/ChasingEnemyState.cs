using Characters;
using Characters.Enemy;
using UnityEngine.AI;


namespace Enemy.State
{
    public class ChasingEnemyState : IEnemyState
    {
        private NavMeshAgent _agent;
        
        public void EnterState(IEnemy enemy)
        {
            _agent = enemy.Agent;
            /*character.SetAnimation("Run", true);
            character.ResumeMovement();*/
        }
        
        // ReSharper disable Unity.PerformanceAnalysis
        public void UpdateState(IEnemy enemy)
        {
            _agent.SetDestination(enemy.CurrentTarget.transform.position);
            enemy.TargetInAttackRange(2f);
            enemy.TargetNotInChaseRange(10f);
        }

        public void ExitState(IEnemy enemy)
        {
            
        }
    }
}
