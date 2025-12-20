using UnityEngine;

public class DoorInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private bool requiresKey = true;
    public bool isOpen = false;
    public bool isUnlocked = false;
    public bool isAnimating = false;
    private Animator doorAnimator;

    public bool IsOpen => isOpen;

    private void Start()
    {
        doorAnimator = GetComponentInParent<Animator>();
        
        if (doorAnimator == null)
        {
            Debug.LogError("No Animator found on door!");
        }

        if (!requiresKey)
        {
            isUnlocked = true;
        }
    }

    public void OnInteract()
{
    Debug.Log("OnInteract called at " + Time.time);
    
    if (requiresKey && !isUnlocked)
    {
        if (!Player.Instance.hasKey)
        {
            Debug.Log("Door is locked. You need a key!");
            return;
        }
        
        isUnlocked = true;
        Player.Instance.hasKey = false;
        Debug.Log("Door unlocked! Press E again to open.");
        return;
    }

    if (isAnimating)
    {
        Debug.Log("Door is already moving...");
        return;
    }

    isOpen = !isOpen;
    isAnimating = true;
    
    doorAnimator.ResetTrigger("Open");
    doorAnimator.ResetTrigger("Close");
    
    if (isOpen)
    {
        doorAnimator.SetTrigger("Open");
        Debug.Log("Door opening");
    }
    else
    {
        doorAnimator.SetTrigger("Close");
        Debug.Log("Door closing");
    }

    Invoke(nameof(ResetAnimating), 1.5f);
}

    private void ResetAnimating()
    {
        isAnimating = false;
        doorAnimator.ResetTrigger("Open");
        doorAnimator.ResetTrigger("Close");
    }
}