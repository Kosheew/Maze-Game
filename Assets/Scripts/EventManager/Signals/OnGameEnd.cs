namespace CustomEventBus.Signals
{
    public class OnGameEnd
    {
        public readonly string Value;

        public OnGameEnd(string value)
        {
            Value = value;
        }
    }
}