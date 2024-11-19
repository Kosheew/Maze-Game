using Character;
using Character.Command;

namespace Commands
{
    public class CommandPlayerFactory: CommandCharacterFactory
    {
        public override void Inject(DependencyContainer container)
        {
            base.Inject(container);
        }
        
        public void CreateDeadCommand(IPlayer player)
        {
            ICommand deadCommand = new DeadCommand(Container, player);
            Invoker.SetCommand(deadCommand);
            Invoker.ExecuteCommands();
        }

        public void CreateMoveCommand(IPlayer player)
        {
            ICommand moveCommand = new MoveCommand(Container, player);
            Invoker.SetCommand(moveCommand);
            Invoker.ExecuteCommands();
        }
    }
}