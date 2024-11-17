using UserController;
using Character;
using UnityEngine;

public class MoveState : ICharacterState
{
    private Player _player;
    private Camera _camera;

    private CharacterController _characterController;
    private AudioSettings _audioSettings;

    private IFootstepHandler _footstepHandler;
    private IUserController _userController;
    private IMovement _movement;
    
    public void EnterState(ICharacter character)
    {
        _player = (Player)character;
        
        _characterController = _player.CharacterController;
        _audioSettings = _player.AudioSettings;
        _footstepHandler = _player.FootstepHandler;
        _userController = _player.UserController;
        _movement = _player.Movement;
        _camera = _player.CameraMain;
    }

    public void UpdateState(ICharacter character)
    {
        var lookX = _userController.GetLookDirectionX();
        var lookY = _userController.GetLookDirectionY();
        var moveVertical = _userController.GetMoveDirectionVertical();
        var moveHorizontal = _userController.GetMoveDirectionHorizontal();

        _movement.RotateCharacter(lookX, lookY, _player.transform, _camera.transform);
        var velocity =_movement.MoveCharacter(moveHorizontal, moveVertical, _player.transform);
        var gravityVelocity = _movement.AddGravity();

        _characterController.Move(_characterController.isGrounded ? velocity : (Vector3)gravityVelocity);

        if (IsMoving(velocity))
        {
            _footstepHandler.PlayFootstepSound();
        }
    }

    public void ExitState(ICharacter character)
    {
        throw new System.NotImplementedException();
    }
    
    private bool IsMoving(Vector3 velocity)
    {
        var velocityMagnitude = new Vector3(velocity.x, 0, velocity.z).magnitude;
        return velocityMagnitude > 0.01f;
    }
}
