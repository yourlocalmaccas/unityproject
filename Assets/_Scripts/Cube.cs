using UnityEngine;

public class Cube : MonoBehaviour, IInteractable
{

    private float lifeTime;
    public void OnInteract()
    {
        Destroy(gameObject, lifeTime);
        
    }

    private void OnDestroy() {
        Debug.Log("Cube destroyed");   
    }
}
