using CharacterSettings;
using UnityEngine;
using UnityEngine.AI;

namespace Characters.Enemy
{
    public interface IEnemy
    {
        public EnemySetting EnemySetting{ get;}
        public NavMeshAgent Agent { get; }
        public Transform[] PatrolTargets { get; }
        public Transform CurrentTarget { get; }
        public CharacterAnimator CharacterAnimator { get; }
        public Transform MainPosition { get; }
        public IFootstepHandler FootstepHandler { get; }
        public void TargetInChaseRange(float distance);
        public void TargetInAttackRange(float distance);
    }
}