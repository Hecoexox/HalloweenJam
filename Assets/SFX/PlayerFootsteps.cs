using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioSource footstepSound; 
    public float stepInterval = 0.5f;

    private float stepTimer = 0f;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        
        if (characterController.isGrounded && characterController.velocity.magnitude > 0.1f)
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0f)
            {
                footstepSound.Play();
                stepTimer = stepInterval;
            }
        }
        else
        {
           
            if (footstepSound.isPlaying)
            {
                footstepSound.Stop();
            }
            
            stepTimer = stepInterval;
        }
    }
}
