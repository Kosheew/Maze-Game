using Character;
using Character.Command;

namespace Commands
{
    public class CommandEnemyFactory: CommandCharacterFactory
    {
        protected CommandEnemyFactory(DependencyContainer container) : base(container) { }

        public void CreateAttackCommand(ICharacter character)
        {
            ICommand attackCommand = new AttackCommand(Container, character);
            Invoker.SetCommand(attackCommand);
            Invoker.ExecuteCommands();
        }

        public void CreatePatrolledCommand(ICharacter character)
        {
            ICommand patrolledCommand = new PatrolledCommand(Container, character);
            Invoker.SetCommand(patrolledCommand);
            Invoker.ExecuteCommands();
        }

        public void CreateChasingCommand(ICharacter character)
        {
            ICommand chasingCommand = new ChasingCommand(Container, character);
            Invoker.SetCommand(chasingCommand);
            Invoker.ExecuteCommands();
        }

        public void CharacterIdleCommand(ICharacter character)
        {
            ICommand idleCommand = new IdleCommand(Container, character);
            Invoker.SetCommand(idleCommand);
            Invoker.ExecuteCommands();
        }
    }
}