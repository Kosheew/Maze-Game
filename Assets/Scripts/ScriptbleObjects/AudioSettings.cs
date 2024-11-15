using UnityEngine;

[CreateAssetMenu(fileName = "New Audio Settings", menuName = "Audio Settings")]
public class AudioSettings : ScriptableObject 
{ 
    [SerializeField] private float stepInterval; 
    [SerializeField] private AudioClip[] stepAudioClips;
   
    public AudioClip[] StepAudioClips => stepAudioClips;
    public float StepInterval => stepInterval;
}

