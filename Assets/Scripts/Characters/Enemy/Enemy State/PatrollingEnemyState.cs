using Character;
using Enemy.Command;
using UnityEngine;
using UnityEngine.AI;
using Character.Enemy;
using CharacterSettings;
using Character.Enemy;


namespace Enemy.State
{
    public class PatrollingEnemyState : IEnemyState
    {
        private NavMeshAgent _agent;
        private IFootstepHandler _footstepHandler;
        private Transform[] _targets;
        
        private int _currentIndex;
        private float _chaseDistance = 10;
        
        public void EnterState(IEnemy enemy)
        {
            _agent = enemy.Agent;
       //     _footstepHandler = enemy.FootstepHandler;
            _targets = enemy.PatrolTargets;
            _currentIndex = 0;
 
        }

        public void UpdateState(IEnemy enemy)
        {
        //    enemy.TargetInChaseRange(enemy.CurrentTarget.position);

            if (HasReachedDestination())
            {
               // SetNextPatrolPoint(character.MyPosition);
            }
        }

        public void ExitState(IEnemy enemy)
        {
            // Логіка виходу зі стану
        }

        private bool HasReachedDestination()
        {
            return _agent != null && _agent.remainingDistance <= 0.1f;
        }

        private void SetNextPatrolPoint(Transform pos)
        {
            _currentIndex = (_currentIndex + 1) % _targets.Length;
            
            Vector3 nextPatrolPoint = _targets[_currentIndex].position;
            
            Vector3 direction = (nextPatrolPoint - pos.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            pos.rotation = Quaternion.Slerp(pos.rotation, lookRotation, Time.deltaTime * 2);
            
            _footstepHandler?.PlayFootstepSound();
            
            _agent.SetDestination(nextPatrolPoint);
        }
        
       
    }
}
