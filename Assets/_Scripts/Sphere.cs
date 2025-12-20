using UnityEngine;

public class Sphere : MonoBehaviour, IInteractable
{   

    [SerializeField] private float lifeTime;

    public void OnInteract()
    {
        Debug.Log("Sphere interacted with!");
        Destroy(gameObject, lifeTime); 
    }
}
