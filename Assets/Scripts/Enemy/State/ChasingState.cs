namespace Enemy.State
{
    /// <summary>
    /// Represents the state where the enemy chases the player.
    /// The enemy will pursue the player when they are within chase range,
    /// switch to the attacking state when within attack range, 
    /// or return to the patrolling state if the player escapes the chase range.
    /// </summary>
    public class ChasingState : IEnemyState
    {
        /// <summary>
        /// Called when entering the chasing state.
        /// Sets the enemy's animation to "Run" and resumes movement.
        /// </summary>
        /// <param name="enemy">The enemy state manager controlling the enemy.</param>
        public void EnterState(EnemyStateManager enemy)
        {
            enemy.SetAnimation("Run", true);
            enemy.ResumeMovement();
        }

        /// <summary>
        /// Called on each frame while in the chasing state.
        /// Checks the player's position to determine if the enemy should
        /// switch states based on the player's distance.
        /// </summary>
        /// <param name="enemy">The enemy state manager controlling the enemy.</param>
        public void UpdateState(EnemyStateManager enemy)
        {
            if (!enemy.IsPlayerInChaseRange())
            {
                enemy.SwitchState(enemy.PatrollingState);
            }
            else if (enemy.IsPlayerInAttackRange())
            {
                enemy.SwitchState(enemy.AttackingState);
            }
            else
            {
                enemy.SetChaseDestination();
            }
        }
    }
}
