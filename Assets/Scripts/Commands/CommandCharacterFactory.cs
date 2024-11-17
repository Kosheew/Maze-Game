using Character;
using Character.Command;

public class CommandCharacterFactory
{
    private readonly CommandInvoker _invoker;
    private readonly DependencyContainer _container;
    
    private CommandCharacterFactory(DependencyContainer container)
    {
        _invoker = container.Resolve<CommandInvoker>();
        _container = container;
    }

    public void CreateAttackCommand(ICharacter character)
    {
        ICommand attackCommand = new AttackCommand(_container, character);
        _invoker.SetCommand(attackCommand);
        _invoker.ExecuteCommands();
    }

    public void CreatePatrolledCommand(ICharacter character)
    {
        ICommand patrolledCommand = new PatrolledCommand(_container, character);
        _invoker.SetCommand(patrolledCommand);
        _invoker.ExecuteCommands();
    }

    public void CreateChasingCommand(ICharacter character)
    {
        ICommand chasingCommand = new ChasingCommand(_container, character);
        _invoker.SetCommand(chasingCommand);
        _invoker.ExecuteCommands();
    }

    public void CharacterIdleCommand(ICharacter character)
    {
        ICommand idleCommand = new IdleCommand(_container, character);
        _invoker.SetCommand(idleCommand);
        _invoker.ExecuteCommands();
    }
    
    public void CreateDeadCommand(ICharacter character)
    {
        ICommand deadCommand = new DeadCommand(_container, character);
        _invoker.SetCommand(deadCommand);
        _invoker.ExecuteCommands();
    }

    public void CreateMoveCommand(ICharacter character)
    {
        ICommand moveCommand = new MoveCommand(_container, character);
        _invoker.SetCommand(moveCommand);
        _invoker.ExecuteCommands();
    }
}
