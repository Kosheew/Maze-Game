using Character;

namespace Enemy.State
{

    public class PatrollingCharacterState : ICharacterState
    {
        private Enemy _enemy;
        
        public void EnterState(ICharacter character)
        {
            _enemy = (Enemy)character;
            _enemy.SetAnimation("Run", true); 
        }


        public void UpdateState(ICharacter character)
        {
            _enemy.PlayerInChaseRange();
            
            if (_enemy.HasReachedDestination())
            {
                _enemy.SetNextPatrolPoint(); 
            }
        }

        public void ExitState(ICharacter character)
        {
            
        }
    }
}
