using CharacterSettings.StateSettings;
using UnityEngine;

namespace Characters.Enemy
{
    public interface IChasingTarget
    {
        public ChasingState ChasingState { get; }
        public void TargetInChaseRange(Transform target);
    }
}