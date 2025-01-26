using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName ="SoundContainer", menuName = "Sound/SoundContainer")]
public class SoundContainer : ScriptableObject
{
    public List<AudioClip> clips;
}
