using Characters;
using UnityEngine;
using UnityEngine.AI;
using Characters.Enemy;
using CharacterSettings;
using Commands;

namespace Enemy.State
{
    public class PatrollingEnemyState : IEnemyState
    {
        private NavMeshAgent _agent;
        private EnemySetting _enemySetting;
        private IFootstepHandler _footstepHandler;
        private Transform[] _targets;
        private CharacterAnimator _characterAnimator;
        private CommandEnemyFactory _commandEnemy;
        
        private int _currentIndex;
        private float _chaseDistance;
        
        public void EnterState(IEnemy enemy)
        {
            _enemySetting = enemy.EnemySetting;
            _agent = enemy.Agent;
            _footstepHandler = enemy.FootstepHandler;
            _targets = enemy.PatrolTargets;
            _chaseDistance = _enemySetting.ChaseDistance;
            _characterAnimator = enemy.CharacterAnimator;
            _commandEnemy = enemy.CommandEnemy;
            
            _currentIndex = 0;
        }

        public void UpdateState(IEnemy enemy)
        {
            _characterAnimator.Running(_agent.velocity.magnitude);
            
            if (Vector3.Distance(enemy.MainPosition.position, enemy.CurrentTarget.position) < 10 && enemy.CurrentTarget)
            {
                Debug.Log("Chase");
                _commandEnemy.CreateChasingCommand(enemy);
            }
            
            if (HasReachedDestination())
            {
                SetNextPatrolPoint(enemy.MainPosition);
            }
            
            _footstepHandler.PlayFootstepSound();
        }

        public void ExitState(IEnemy enemy)
        {
            
        }

        private bool HasReachedDestination()
        {
            return _agent && _agent.remainingDistance <= 0.1f;
        }

        private void SetNextPatrolPoint(Transform pos)
        {
            _currentIndex = (_currentIndex + 1) % _targets.Length;
            
            var nextPatrolPoint = _targets[_currentIndex].position;
            
            var direction = (nextPatrolPoint - pos.position).normalized;
            var lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            pos.rotation = Quaternion.Slerp(pos.rotation, lookRotation, Time.deltaTime * 2);
            _agent.SetDestination(nextPatrolPoint);
        }
    }
}
