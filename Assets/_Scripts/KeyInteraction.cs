using UnityEngine;

public class KeyInteraction : MonoBehaviour, IInteractable
{
    public void OnInteract()
    {
        Player player = Player.Instance;
        
        if (player == null)
        {
            Debug.LogError("Player instance not found!");
            return;
        }

        print("Found player: " + player.name);
        
       
        player.hasKey = true;
        print("Player picked up key!");
        
        Destroy(gameObject);
    }
}