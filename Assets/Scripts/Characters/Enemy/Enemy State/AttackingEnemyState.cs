using Characters;
using Characters.Enemy;
using Commands;
using UnityEngine;

namespace Enemy.State
{

    public class AttackingEnemyState : IEnemyState
    {
        private CharacterAnimator _characterAnimator;
        private CommandEnemyFactory _commandFactory;
        
        private float _attackInterval = 1f;
        private float _nextAttack = 0;
        
        public void EnterState(IEnemy enemy)
        {
            enemy.Agent.isStopped = true;
            enemy.Agent.velocity = Vector2.zero;
            _characterAnimator = enemy.CharacterAnimator;
            _commandFactory = enemy.CommandEnemy;

            /*enemy.SetAnimation("Run", false);
            enemy.AttackPlayer();*/
        }
        
       
        public void UpdateState(IEnemy enemy)
        {
            var direction = (enemy.CurrentTarget.position - enemy.MainPosition.position).normalized;
            var lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            enemy.MainPosition.rotation = Quaternion.Slerp(enemy.MainPosition.rotation, lookRotation, Time.deltaTime * 2);
            
            if(!(Time.time >= _nextAttack)) return;
            _characterAnimator.Attacking();
            _nextAttack = Time.time + _attackInterval;
            
            if (Vector3.Distance(enemy.MainPosition.position, enemy.CurrentTarget.position) > 3 && enemy.CurrentTarget)
            {
                _commandFactory.CreateChasingCommand(enemy);
            }
            
        }

        public void ExitState(IEnemy enemy)
        {
            enemy.Agent.isStopped = false;
        }
    }
}
