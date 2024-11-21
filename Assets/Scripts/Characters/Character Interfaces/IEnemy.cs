using Characters.Character_Interfaces;
using CharacterSettings;
using Commands;
using UnityEngine;
using UnityEngine.AI;

namespace Characters.Enemy
{
    public interface IEnemy: IPatrolled, IFootstepCharacterAudio, ICharacterAnimate, ITargetHandler, IAttackCharacterAudio
    {
        public EnemySetting EnemySetting{ get;}
        public Transform MainPosition { get; }
        public CommandEnemyFactory CommandEnemy { get; }
    }
}