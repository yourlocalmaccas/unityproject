using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DoorInteract : MonoBehaviour, IInteractable
{
    [Header("Settings")]
    public string nextSceneName = "EndScene"; 
    private bool isUnlocked = false;
    private bool isOpen = false;

    [Header("References")]
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip lockClip;
    public AudioClip unlockClip;
    public AudioClip openClip;

    public void OnInteract()
    {
        if (GameManager.Instance.coinCounter < 3)
        {
            if(animator) animator.SetTrigger("Locked");
            if(audioSource) audioSource.PlayOneShot(lockClip);
            
            NotificationSystem.Instance.ShowNotification("The door is locked. Find 3 keys.", 3f);
            return; 
        }

        if (!isUnlocked)
        {
            isUnlocked = true;
            if(audioSource) audioSource.PlayOneShot(unlockClip);
            return; 
        }

        if (!isOpen)
        {
            isOpen = true;
            if(animator) animator.SetTrigger("OpenDoor");
            if(audioSource) audioSource.PlayOneShot(openClip);
            
            StartCoroutine(WinSequence());
        }
    }

    private IEnumerator WinSequence()
{
  
    yield return new WaitForSeconds(1.0f);

    if (animator != null)
    {
        animator.enabled = false;
        Debug.Log("Animator disabled to keep door open.");
    }

    yield return new WaitForSeconds(4.0f);
    SceneManager.LoadScene(nextSceneName);
}
}