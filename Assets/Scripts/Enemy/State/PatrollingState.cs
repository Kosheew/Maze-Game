namespace Enemy.State
{
    /// <summary>
    /// Represents the patrolling state of the enemy.
    /// </summary>
    public class PatrollingState : IEnemyState
    {
        /// <summary>
        /// Enters the patrolling state and sets the next patrol point.
        /// </summary>
        /// <param name="enemy">The enemy state manager controlling the enemy.</param>
        public void EnterState(EnemyStateManager enemy)
        {
            enemy.SetNextPatrolPoint();
            enemy.SetAnimation("Run", true); // Start running animation while patrolling
        }

        /// <summary>
        /// Updates the patrolling state. Checks if the player is in chase range
        /// or if the enemy has reached its patrol destination.
        /// </summary>
        /// <param name="enemy">The enemy state manager controlling the enemy.</param>
        public void UpdateState(EnemyStateManager enemy)
        {
            if (enemy.IsPlayerInChaseRange())
            {
                enemy.SwitchState(enemy.ChasingState); // Switch to chasing state if player is nearby
            }
            else if (enemy.HasReachedDestination())
            {
                enemy.SetNextPatrolPoint(); // Set the next patrol point
            }
        }
    }
}
