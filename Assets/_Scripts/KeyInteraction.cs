using UnityEngine;

public class KeyInteraction : MonoBehaviour, IInteractable
{
    public GameObject flashlightToEnable;
    public GameObject wallColliderToDestroy;

    public void OnInteract()
    {
    
        if (CursorImage.instance != null)
        {
            CursorImage.instance.gameObject.SetActive(false);
            Debug.Log("Cursor Off");
        }

        if (flashlightToEnable != null)
        {
            flashlightToEnable.SetActive(true);
            Debug.Log("Flashlight On");
        }

        if (wallColliderToDestroy != null)
        {
            Destroy(wallColliderToDestroy);
        }

        GameManager.Instance.coinCounter++;
        print ("Key(s): " + GameManager.Instance.coinCounter);
        Destroy(gameObject);
    }
}