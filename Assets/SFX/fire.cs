using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firescript : MonoBehaviour
{
    public AudioSource fireAudioSource; 
    public Transform player;
    public float maxVolumeDistance = 3f; 
    public float minVolumeDistance = 10f; 

    private void Start()
    {
        if (fireAudioSource == null)
        {
            fireAudioSource = GetComponent<AudioSource>();
        }

        if (fireAudioSource != null)
        {
            fireAudioSource.loop = true; 
            fireAudioSource.Play(); 
        }
        else
        {
            Debug.LogWarning("AudioSource atanmadı.");
        }
    }

    private void Update()
    {
        if (fireAudioSource != null && player != null)
        {

            float distance = Vector3.Distance(transform.position, player.position);
            
            float volume = Mathf.Clamp01(1 - (distance - maxVolumeDistance) / (minVolumeDistance - maxVolumeDistance));
            
            fireAudioSource.volume = volume;
        }
    }
}
