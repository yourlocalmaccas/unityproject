using UnityEngine;

public class GameIntroPoint : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
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
