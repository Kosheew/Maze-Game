namespace Character.Command
{
    public class IdleCommand: ICommand
    {
        private readonly StateManager _stateManager;
        private readonly StateFactory _stateFactory;
        private readonly ICharacter _character;
        
        public IdleCommand(DependencyContainer container, ICharacter character)
        {
            _stateManager = container.Resolve<StateManager>();
            _stateFactory = container.Resolve<StateFactory>();
            _character = character;
        }

        public void Execute()
        {
            var characterState = _stateFactory.CreateState(TypeCharacterStates.Idle);
            _stateManager.SetState(characterState, _character);
        }
    }
}