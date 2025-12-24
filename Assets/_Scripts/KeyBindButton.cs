using UnityEngine;
using TMPro;
using System.Collections;

public class KeyBindButton : MonoBehaviour
{
    public TMP_Text buttonText;
    public string actionName;
    private bool isWaiting = false;

    private void Start()
    {
        Invoke("RefreshUI", 0.1f);
    }

    private void OnDisable()
    {
        isWaiting = false;
        StopAllCoroutines();
        RefreshUI();
    }

    public void RefreshUI()
    {
        if (KeybindManager.Instance != null)
        {
            if (actionName == "Interact") buttonText.text = KeybindManager.Instance.Interact.ToString();
            if (actionName == "Flashlight") buttonText.text = KeybindManager.Instance.Flashlight.ToString();
        }
    }

    public void StartRebinding()
    {
        StopAllCoroutines();
        StartCoroutine(WaitForKeyPress());
    }

    IEnumerator WaitForKeyPress()
    {
        isWaiting = true;
        buttonText.text = "...";
        
        yield return null; 

        while (!Input.anyKeyDown)
        {
            if (!gameObject.activeInHierarchy) yield break;
            yield return null;
        }

        foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
            {
                if (KeybindManager.Instance != null)
                {
                    KeybindManager.Instance.UpdateKeybind(actionName, kcode);
                }
                buttonText.text = kcode.ToString();
                break;
            }
        }
        isWaiting = false;
    }
}