/// <summary>
/// Interface for handling footstep sound playback.
/// Any class implementing this interface should provide functionality
/// to play footstep sounds when the player is moving.
/// </summary>
public interface IFootstepHandler
{
    /// <summary>
    /// Plays the footstep sound.
    /// </summary>
    void PlayFootstepSound();
}
