namespace Character.Command
{
    public class AttackCommand : ICommand
    {
        private readonly StateManager _stateManager;
        private readonly StateFactory _stateFactory;
        private readonly ICharacter _character;
        
        public AttackCommand(DependencyContainer container, ICharacter character)
        {
            _stateManager = container.Resolve<StateManager>();
            _stateFactory = container.Resolve<StateFactory>();
            _character = character;
        }

        public void Execute()
        {
            var characterState = _stateFactory.CreateState(TypeCharacterStates.Attacked);
            _stateManager.SetState(characterState, _character);
        }
    }
}
