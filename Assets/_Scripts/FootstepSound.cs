using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip footstepSound;
    
    [Header("Timing Settings")]
    public float stepInterval = 0.5f;     // Time between each step
    public float holdThreshold = 0.15f;   // How long to hold key before first step plays
    
    private float stepTimer;
    private float holdTimer;

    void Update()
    {
        bool isPressingKeys = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;

        if (isPressingKeys)
        {
            holdTimer += Time.deltaTime;

          
            if (holdTimer >= holdThreshold)
            {
                stepTimer += Time.deltaTime;

                if (stepTimer >= stepInterval)
                {
                    PlayFootstep();
                    stepTimer = 0;
                }
            }
        }
        else
        {
            holdTimer = 0;
            stepTimer = stepInterval; 
        }
    }

    void PlayFootstep()
    {
        audioSource.pitch = Random.Range(0.85f, 1.1f);
        audioSource.PlayOneShot(footstepSound);
    }
}