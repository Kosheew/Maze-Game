using Character;
using Character.Command;

namespace Commands
{
    public class CommandPlayerFactory: CommandCharacterFactory
    {
        protected CommandPlayerFactory(DependencyContainer container) : base(container)
        {
        }
        
        public void CreateDeadCommand(ICharacter character)
        {
            ICommand deadCommand = new DeadCommand(Container, character);
            Invoker.SetCommand(deadCommand);
            Invoker.ExecuteCommands();
        }

        public void CreateMoveCommand(ICharacter character)
        {
            ICommand moveCommand = new MoveCommand(Container, character);
            Invoker.SetCommand(moveCommand);
            Invoker.ExecuteCommands();
        }
    }
}