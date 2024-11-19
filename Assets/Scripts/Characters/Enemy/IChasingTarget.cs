using UnityEngine;

namespace Character.Enemy
{
    public interface IChasingTarget
    {
        public void TargetInChaseRange(Transform target);
    }
}