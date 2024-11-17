namespace Character.Command
{
    public class MoveCommand : ICommand
    {
        private readonly StateManager _stateManager;
        private readonly StateFactory _stateFactory;
        private readonly ICharacter _character;
        
        public MoveCommand(DependencyContainer container, ICharacter character)
        {
            _stateManager = container.Resolve<StateManager>();
            _stateFactory = container.Resolve<StateFactory>();
            _character = character;
        }

        public void Execute()
        {
            var characterState = _stateFactory.CreateState(TypeCharacterStates.Move);
            _stateManager.SetState(characterState, _character);
        }
    }
}