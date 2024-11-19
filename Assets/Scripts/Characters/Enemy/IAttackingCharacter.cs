using UnityEngine;

namespace Character.Enemy
{
    public interface IAttackingCharacter
    {
        public void Attack();
        public bool IsTargetAttackRange(Transform target);
    }
}