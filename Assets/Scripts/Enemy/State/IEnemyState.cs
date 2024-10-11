namespace Enemy
{
    /// <summary>
    /// Interface for defining enemy states.
    /// </summary>
    public interface IEnemyState
    {
        /// <summary>
        /// Called when entering the state.
        /// </summary>
        /// <param name="enemy">The enemy state manager controlling the enemy.</param>
        void EnterState(EnemyStateManager enemy);

        /// <summary>
        /// Called on each update while in this state.
        /// </summary>
        /// <param name="enemy">The enemy state manager controlling the enemy.</param>
        void UpdateState(EnemyStateManager enemy);
    }
}
