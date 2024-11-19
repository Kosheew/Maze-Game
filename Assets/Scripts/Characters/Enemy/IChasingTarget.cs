using UnityEngine;

namespace Characters.Enemy
{
    public interface IChasingTarget
    {
        public void TargetInChaseRange(Transform target);
    }
}