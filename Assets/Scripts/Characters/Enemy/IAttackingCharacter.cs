using UnityEngine;

namespace Characters.Enemy
{
    public interface IAttackingCharacter
    {
        public void Attack();
        public bool IsTargetAttackRange(Transform target);
    }
}