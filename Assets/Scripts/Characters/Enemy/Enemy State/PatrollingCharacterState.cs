using Character;
using CharacterSettings.StateSettings;
using Enemy.Command;
using UnityEngine;
using UnityEngine.AI;
using Characters.Enemy;
using CharacterSettings;

namespace Enemy.State
{
    public class PatrollingCharacterState : ICharacterState
    {
        private NavMeshAgent _agent;
        private IFootstepHandler _footstepHandler;
        private Transform[] _targets;
        private PatrollingState _stateSetting;
        private int _currentIndex;

        private CharacterSetting _characterSetting;
        
        public void EnterState(ICharacter character)
        {
            if (character is not IEnemy enemy)
            {
                Debug.LogError("PatrollingCharacterState can only be used by enemies!");
                return;
            }

            _characterSetting = character.CharacterSetting;
            
            _stateSetting = (PatrollingState)_characterSetting.GetStateSettings(TypeCharacterStates.Patrolled);
            _agent = enemy.Agent;
            _footstepHandler = enemy.FootstepHandler;
            _targets = enemy.PatrolTargets;
            _currentIndex = 0;

            if (_agent != null)
            {
                _agent.speed = character.CharacterSetting.MoveSpeed;
            }
        }

        public void UpdateState(ICharacter character)
        {
            if (character is not IEnemy enemy || _targets == null || _targets.Length == 0)
                return;

            enemy.PlayerInChaseRange();

            if (HasReachedDestination())
            {
                SetNextPatrolPoint();
            }
        }

        public void ExitState(ICharacter character)
        {
            // Логіка виходу зі стану
        }

        private bool HasReachedDestination()
        {
            return _agent != null && _agent.remainingDistance <= _stateSetting.DestinationThreshold;
        }

        private void SetNextPatrolPoint()
        {
            _currentIndex = (_currentIndex + 1) % _targets.Length;

            var rotateCommand = new RotateTowardsCommand(_agent.transform, _targets[_currentIndex].position, _characterSetting.TurnSpeed);
            rotateCommand.Execute();

            _footstepHandler?.PlayFootstepSound();

            new SetDestinationCommand(_agent, _targets[_currentIndex].position).Execute();
        }
    }
}
