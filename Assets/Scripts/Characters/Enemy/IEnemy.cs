using Character;
using UnityEngine;
using UnityEngine.AI;

namespace Characters.Enemy
{
    public interface IEnemy: ICharacter
    {
        public NavMeshAgent Agent { get; }
        public Transform[] PatrolTargets { get; }
        public IFootstepHandler FootstepHandler { get; }
        public Transform CurrentTarget { get; }
        public void TargetInChaseRange(float distance);
        public void TargetInAttackRange(float distance);
    }
}