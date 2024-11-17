using UnityEngine;
using UnityEngine.AI;

namespace Enemy.Command
{
    /// <summary>
    /// Command that sets the destination for a NavMeshAgent.
    /// This command is used to direct an enemy character towards a specific point in the game world.
    /// </summary>
    public class SetDestinationCommand : ICommand
    {
        private NavMeshAgent _agent;
        private Vector3 _destination;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetDestinationCommand"/> class.
        /// </summary>
        /// <param name="agent">The NavMeshAgent that will be directed to the destination.</param>
        /// <param name="destination">The target destination for the agent.</param>
        public SetDestinationCommand(NavMeshAgent agent, Vector3 destination)
        {
            _agent = agent;
            _destination = destination;
        }

        /// <summary>
        /// Executes the command to set the agent's destination.
        /// </summary>
        public void Execute()
        {
            _agent.SetDestination(_destination);
        }
    }
}
