namespace Enemy.State
{
    /// <summary>
    /// Represents the state where the enemy attacks the player.
    /// The enemy will initiate an attack when the player is within attack range,
    /// and switch to the chasing state if the player moves out of attack range.
    /// </summary>
    public class AttackingState : IEnemyState
    {
        /// <summary>
        /// Called when entering the attacking state.
        /// Stops the running animation and executes the attack on the player.
        /// </summary>
        /// <param name="enemy">The enemy state manager controlling the enemy.</param>
        public void EnterState(EnemyStateManager enemy)
        {
            enemy.SetAnimation("Run", false);
            enemy.AttackPlayer();
        }

        /// <summary>
        /// Called on each frame while in the attacking state.
        /// Checks if the player is still within attack range to determine if 
        /// the enemy should switch to the chasing state.
        /// </summary>
        /// <param name="enemy">The enemy state manager controlling the enemy.</param>
        public void UpdateState(EnemyStateManager enemy)
        {
            if (!enemy.IsPlayerInAttackRange())
            {
                enemy.SwitchState(enemy.ChasingState);
            }
        }
    }
}
