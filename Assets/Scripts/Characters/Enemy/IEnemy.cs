using UnityEngine;
using UnityEngine.AI;

namespace Character.Enemy
{
    public interface IEnemy
    {
        public NavMeshAgent Agent { get; }
        public Transform[] PatrolTargets { get; }
        public Transform CurrentTarget { get; }
        public void TargetInChaseRange(float distance);
        public void TargetInAttackRange(float distance);
    }
}