using UnityEngine;

namespace Player
{
    /// <summary>
    /// Handles the player's movement and rotation, including acceleration and gravity effects.
    /// Utilizes Unity's CharacterController for smooth movement.
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        private float _currentAngleX = 0f;

        /// <summary>
        /// The gravity scale affecting the player's movement.
        /// </summary>
        private float _gravityScale = -9.8f;

        /// <summary>
        /// The maximum angle the camera can rotate up and down.
        /// </summary>
        [SerializeField] private float _maxClamp = 60;

        /// <summary>
        /// The base speed of the player.
        /// </summary>
        [SerializeField] private float _speedScale = 5f;

        /// <summary>
        /// The speed at which the player turns.
        /// </summary>
        [SerializeField] private float _turnSpeed = 250f;

        /// <summary>
        /// The rate of acceleration applied to the player's speed.
        /// </summary>
        [SerializeField] private float _accelerationRate = 2f;

        private CharacterController characterController;
        private Camera _camera;

        /// <summary>
        /// Initializes the PlayerMovement component by acquiring necessary references.
        /// </summary>
        public void Init()
        {
            _camera = Camera.main;
            characterController = GetComponent<CharacterController>();
        }

        /// <summary>
        /// Increases the player's speed by the acceleration rate.
        /// </summary>
        public void AddAcseleration()
        {
            _speedScale += _accelerationRate;
        }

        /// <summary>
        /// Decreases the player's speed by the acceleration rate.
        /// </summary>
        public void SubAcseleration()
        {
            _speedScale -= _accelerationRate;
        }

        /// <summary>
        /// Rotates the player based on mouse input.
        /// </summary>
        /// <param name="mouseX">The mouse movement along the X-axis.</param>
        /// <param name="mouseY">The mouse movement along the Y-axis.</param>
        public void RotatePlayer(float mouseX, float mouseY)
        {
            // Rotate the player around the Y-axis based on mouseX input.
            transform.Rotate(new Vector3(0f, mouseX * _turnSpeed * Time.deltaTime, 0f));

            // Adjust the camera's X rotation based on mouseY input.
            _currentAngleX += mouseY * _turnSpeed * Time.deltaTime * -1f;

            // Clamp the camera angle to prevent excessive rotation.
            _currentAngleX = Mathf.Clamp(_currentAngleX, -_maxClamp, _maxClamp);

            // Set the camera's local rotation based on the clamped angle.
            _camera.transform.localEulerAngles = new Vector3(_currentAngleX, 0f, 0f);
        }

        /// <summary>
        /// Moves the character based on input and applies gravity.
        /// </summary>
        /// <param name="horizontal">The horizontal input value.</param>
        /// <param name="vertical">The vertical input value.</param>
        public void MoveCharacter(float horizontal, float vertical)
        {
            // Create a velocity vector based on input and gravity.
            Vector3 velocity = new Vector3(horizontal, _gravityScale, vertical);

            // Convert local velocity to world space and apply speed scale.
            velocity = transform.TransformDirection(velocity) * _speedScale;

            // Move the character controller based on the calculated velocity.
            characterController.Move(velocity * Time.deltaTime);
        }
    }
}
