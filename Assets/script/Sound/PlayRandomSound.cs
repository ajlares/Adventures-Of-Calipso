using UnityEngine;
using System.Collections.Generic;

public class PlayRandomSound : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    public void PlaySound(SoundContainer soundContainer)
    {
        int i = Random.Range(0,soundContainer.clips.Count);
        audioSource.pitch = Random.Range(0.75f,1.25f);
        audioSource.PlayOneShot(soundContainer.clips[i]);
    }
}
