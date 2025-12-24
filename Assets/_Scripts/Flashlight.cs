using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject lightSource; 
    private bool isOn = true;

    void Update()
    {
        if (KeybindManager.Instance == null) return;

        if (Input.GetKeyDown(KeybindManager.Instance.Flashlight))
        {
            isOn = !isOn;
            lightSource.SetActive(isOn);
        }
    }
}