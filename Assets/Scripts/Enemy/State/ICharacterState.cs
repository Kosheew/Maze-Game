namespace Character
{
    public interface ICharacterState
    {
        void EnterState(ICharacter character);
        void UpdateState(ICharacter character);
        void ExitState(ICharacter character);
    }
}
