using Characters.Character_Interfaces;
using CharacterSettings;
using Commands;
using UnityEngine;
using System.Collections;

namespace Characters.Enemy
{
    public interface IEnemy: IPatrolled, IFootstepCharacterAudio, ICharacterAnimate, ITargetHandler, IAttackCharacterAudio
    {
        public EnemySetting EnemySetting{ get;}
        public Transform MainPosition { get; }
        public CommandEnemyFactory CommandEnemy { get; }
        public Transform EyesPosition { get; }
        
        public Coroutine StartTheCoroutine(IEnumerator routine);
        public void StopTheCoroutine(Coroutine routine);
    }
}