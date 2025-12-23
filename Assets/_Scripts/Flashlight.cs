using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    
    public GameObject lightSource; 
    private bool isOn = true;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isOn = !isOn;
            lightSource.SetActive(isOn);
  
        }
    }
}