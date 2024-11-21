using CharacterSettings;
using Commands;
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
        public CommandEnemyFactory CommandEnemy { get; }
        public IFootstepHandler FootstepHandler { get; }
    }
}