using UserController;
using Characters;
using UnityEngine;
using CharacterSettings;

namespace Player.State
{
    public class MovementState : IPlayerState
    {
        private Camera _camera;

        private CharacterController _characterController;
        private CharacterAudioSettings _characterAudioSettings;
        private PlayerSetting _playerSetting;

        private IFootstepHandler _footstepHandler;
        private IUserController _userController;
        private IMovement _movement;
        
        public void EnterState(IPlayer player)
        {
            _playerSetting = player.PlayerSetting;
            _characterController = player.Controller; 
            _userController = player.UserController;
            _footstepHandler = player.FootstepHandler;
            _camera = player.CameraMain;
            
            _movement = new CharacterMovement(
                _playerSetting.MaxClamp,
                _playerSetting.MoveSpeed,
                _playerSetting.AccelerationRate,
                _playerSetting.TurnSpeed);
        }

        public void UpdateState(IPlayer player)
        {
            var lookX = _userController.GetLookDirectionX();
            var lookY = _userController.GetLookDirectionY();
            var moveVertical = _userController.GetMoveDirectionVertical();
            var moveHorizontal = _userController.GetMoveDirectionHorizontal();
            
            _movement.RotateCharacter(lookX, lookY, player.TransformMain, _camera.transform);
            var velocity = _movement.MoveCharacter(moveHorizontal, moveVertical, player.TransformMain);
            var gravityVelocity = _movement.AddGravity();

            _characterController.Move(_characterController.isGrounded ? velocity : (Vector3)gravityVelocity);

            if (IsMoving(velocity))
            {
                _footstepHandler.PlayFootstepSound();
            }
        }

        public void ExitState(IPlayer player)
        {
            throw new System.NotImplementedException();
        }

        private bool IsMoving(Vector3 velocity)
        {
            var velocityMagnitude = new Vector3(velocity.x, 0, velocity.z).magnitude;
            return velocityMagnitude > 0.01f;
        }
    }
}
