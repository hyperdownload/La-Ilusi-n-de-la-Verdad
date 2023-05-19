using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] footstepSounds;
    public float footstepDelay = 0.5f;
    private float lastFootstepTime = 0f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void PlayFootstepSound()
    {
        if (Time.time - lastFootstepTime > footstepDelay && footstepSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, footstepSounds.Length);
            audioSource.clip = footstepSounds[randomIndex];
            audioSource.Play();
            lastFootstepTime = Time.time;
        }
    }
}