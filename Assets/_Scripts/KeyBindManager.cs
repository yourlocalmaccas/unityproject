using UnityEngine;

public class KeybindManager : MonoBehaviour
{
    public static KeybindManager Instance;
    public KeyCode Interact { get; set; }
    public KeyCode Flashlight { get; set; }

    void Awake()
{
    if (Instance == null)
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    else if (Instance != this)
    {
        Destroy(gameObject);
        return;
    }

    Interact = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("InteractKey", "E"));
    Flashlight = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("FlashlightKey", "F"));
}
    public void UpdateKeybind(string action, KeyCode newKey)
    {
        if (action == "Interact") { Interact = newKey; PlayerPrefs.SetString("InteractKey", newKey.ToString()); }
        if (action == "Flashlight") { Flashlight = newKey; PlayerPrefs.SetString("FlashlightKey", newKey.ToString()); }
        PlayerPrefs.Save();
    }
}