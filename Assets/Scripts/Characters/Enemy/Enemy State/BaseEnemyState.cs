using Characters;
using Characters.Enemy;
using UnityEngine;


namespace Enemy.State
{
    public abstract class BaseEnemyState : IEnemyState
    {
        protected virtual void RotateTowards(IEnemy enemy, Transform target)
        {
            var direction = (target.position - enemy.MainPosition.position).normalized;
            var lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            enemy.MainPosition.rotation = Quaternion.Slerp(enemy.MainPosition.rotation, lookRotation, Time.deltaTime * 5);
        }

        protected virtual bool IsTargetInRange(IEnemy enemy, Transform target, float range)
        {
            return Vector3.Distance(enemy.MainPosition.position, target.position) <= range;
        }

        protected virtual bool CanSeeTarget(IEnemy enemy, Transform target)
        {
            var setting = enemy.EnemySetting;
            var directionToTarget = (target.position - enemy.EyesPosition.position).normalized;
            var angleToTarget = Vector3.Angle(enemy.EyesPosition.forward, directionToTarget);

            if (angleToTarget > setting.FieldOfViewAngle / 2f)
                return false;

            if (Physics.Raycast(enemy.EyesPosition.position, directionToTarget, out var hit, setting.VisionDistance, setting.VisionMask))
            {
                return hit.transform == target; 
            }

            return false;
        }

        public abstract void EnterState(IEnemy enemy);
        public abstract void UpdateState(IEnemy enemy);
        public abstract void ExitState(IEnemy enemy);
    }
}