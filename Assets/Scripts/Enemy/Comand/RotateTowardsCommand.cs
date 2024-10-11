using UnityEngine;

namespace Enemy.Command
{
    /// <summary>
    /// Command that rotates a transform towards a specified target direction.
    /// This command is used to smoothly rotate an enemy character to face a target point in the game world.
    /// </summary>
    public class RotateTowardsCommand : ICommand
    {
        private Transform _transform;
        private Vector3 _target;
        private float _rotationSpeed;

        /// <summary>
        /// Initializes a new instance of the <see cref="RotateTowardsCommand"/> class.
        /// </summary>
        /// <param name="transform">The Transform that will be rotated.</param>
        /// <param name="target">The target direction to rotate towards.</param>
        /// <param name="rotationSpeed">The speed of the rotation.</param>
        public RotateTowardsCommand(Transform transform, Vector3 target, float rotationSpeed)
        {
            _transform = transform;
            _target = target;
            _rotationSpeed = rotationSpeed;
        }

        /// <summary>
        /// Executes the command to rotate the transform towards the target.
        /// </summary>
        public void Execute()
        {
            Vector3 direction = (_target - _transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            _transform.rotation = Quaternion.Slerp(_transform.rotation, lookRotation, Time.deltaTime * _rotationSpeed);
        }
    }
}
