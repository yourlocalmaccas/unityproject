using UnityEngine;

public class CursorCollidePoint : MonoBehaviour
{
    public GameObject Flashlight;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            CursorImage.instance.gameObject.SetActive(true);
            Debug.Log("Cursor On");
            Flashlight.gameObject.SetActive(false);
            Debug.Log("Flashlight off");
        }
    }

    
}