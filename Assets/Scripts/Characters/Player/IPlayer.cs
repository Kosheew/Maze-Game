using UnityEngine;
using UserController;
using CharacterSettings;

namespace Characters
{
    public interface IPlayer
    {
        public PlayerSetting PlayerSetting { get; }
        public CharacterAudioSettings CharacterAudioSettings { get; }
        public CharacterController Controller { get;  }
        public Camera CameraMain { get; }
        public IUserController UserController { get; }
        public IFootstepHandler FootstepHandler { get; }
        public Transform TransformMain { get; }
    }
}