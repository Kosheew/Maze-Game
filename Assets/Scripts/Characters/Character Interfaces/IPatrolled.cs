using UnityEngine;
using UnityEngine.AI;

namespace Characters.Character_Interfaces
{
    public interface IPatrolled
    {
        public NavMeshAgent Agent { get; }
        public Transform[] PatrolTargets { get; }
    }
}