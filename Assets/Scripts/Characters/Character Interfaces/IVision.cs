using UnityEngine;

namespace Characters.Character_Interfaces
{
    public interface IVision
    {
        public bool CanSeeTarget(Transform target);
    }
}