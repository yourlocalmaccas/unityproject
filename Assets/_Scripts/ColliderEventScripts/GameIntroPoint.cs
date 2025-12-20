using UnityEngine;

public class GameIntroPoint : MonoBehaviour
{
    public DoorInteract door; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && door != null && door.isUnlocked)
        {
            UIManager uiManager = FindFirstObjectByType<UIManager>();
            if (uiManager != null)
            {
                uiManager.ShowStatus("Your journey has begun!", 5f);
            }

            gameObject.SetActive(false);
        }
    }
}
