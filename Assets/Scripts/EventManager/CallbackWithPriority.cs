namespace CustomEventBus
{
    /// <summary>
    /// Represents a callback function with an associated priority level.
    /// The higher the priority value, the earlier the callback will be invoked.
    /// </summary>
    public class CallbackWithPriority
    {
        /// <summary>
        /// Gets the priority level of the callback.
        /// </summary>
        public readonly int Priority;

        /// <summary>
        /// Gets the callback function.
        /// </summary>
        public readonly object Callback;

        /// <summary>
        /// Initializes a new instance of the <see cref="CallbackWithPriority"/> class.
        /// </summary>
        /// <param name="priority">The priority level of the callback.</param>
        /// <param name="callback">The callback function to be invoked.</param>
        public CallbackWithPriority(int priority, object callback)
        {
            Priority = priority;
            Callback = callback;
        }
    }
}
