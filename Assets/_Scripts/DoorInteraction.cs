using UnityEngine;

public class DoorInteract : MonoBehaviour, IInteractable
{
    [Header("Door Settings")]
    public bool requiresKey = true;
    public bool isUnlocked = false;
    public bool isOpen = false;

    [Header("References")]
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip lockClip;
    public AudioClip unlockClip;
    public AudioClip openClip;
    public AudioClip closeClip;

    public void OnInteract()
    {
        Player player = Player.Instance;

        if (player == null) return;

        if (requiresKey && !isUnlocked)
        {
            if (player.hasKey)
            {
                isUnlocked = true;
                audioSource.PlayOneShot(unlockClip);
                Debug.Log("Door unlocked!");
            }
            else
            {
                animator.SetTrigger("Locked");
                audioSource.PlayOneShot(lockClip);
                Debug.Log("Door is locked");
                return;
            }
        }

        if (!isOpen && isUnlocked)
        {
            animator.SetTrigger("OpenDoor");
            audioSource.PlayOneShot(openClip);
            isOpen = true;
            Debug.Log("Door opened");
        }
        else
        {
            animator.SetTrigger("CloseDoor");
            audioSource.PlayOneShot(closeClip);
            isOpen = false;
            Debug.Log("Door closed");
        }
    }
}
