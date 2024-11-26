using Audio;
using Characters.Character_Interfaces;
using Characters.Player;
using CharacterSettings;
using Commands;
using UnityEngine;
using UnityEngine.AI;

namespace Characters.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(Animator))]
    public class EnemyController : MonoBehaviour, IEnemy
    {
        
        [SerializeField] private Transform[] patrolTargets;
        [SerializeField] private EnemySetting enemySetting;
        [SerializeField] private EnemyVision vision;
        
        private AudioSource AudioSource => GetComponent<AudioSource>();
        public NavMeshAgent Agent => GetComponent<NavMeshAgent>();
        private Animator Animator => GetComponent<Animator>();
        public EnemySetting EnemySetting => enemySetting;
        public Transform[] PatrolTargets => patrolTargets;
        public Transform CurrentTarget => _currentTarget;
        public CharacterAnimator CharacterAnimator { get; private set; }
        public IFootstepAudioHandler FootstepHandler { get; private set; }
        public AttackAudioHandler AttackAudio { get; private set; }
        public Transform MainPosition => transform;

        private CharacterAudioSettings _characterAudioSettings;
        private Transform _currentTarget;
        public CommandEnemyFactory CommandEnemy { get; private set; }
        public EnemyVision Vision => vision;


        public void Inject(DependencyContainer container)
        {
            Agent.speed = enemySetting.MoveSpeed;
            
            _characterAudioSettings = enemySetting.CharacterAudioSettings;
            
            _currentTarget = container.Resolve<PlayerController>().TransformMain;
            CommandEnemy = container.Resolve<CommandEnemyFactory>();

            FootstepHandler = new FootstepAudioAudioHandler(AudioSource, _characterAudioSettings);
            AttackAudio = new AttackAudioHandler(AudioSource, _characterAudioSettings);
            CharacterAnimator = new CharacterAnimator(Animator);
            
            CommandEnemy.CreatePatrolledCommand(this);
        }


    }
}
