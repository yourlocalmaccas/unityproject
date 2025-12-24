using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public Slider sensSlider;
    public TMP_Text sensValueText;
    private bool isPaused = false;

    void Start()
    {
        settingsPanel.SetActive(false);
        if (sensSlider != null)
        {
            sensSlider.minValue = 0.1f;
            sensSlider.maxValue = 3.0f;
        }
        LoadCurrentSettings();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        settingsPanel.SetActive(isPaused);

        if (isPaused)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            KeyBindButton[] rebindButtons = settingsPanel.GetComponentsInChildren<KeyBindButton>();
            foreach(var btn in rebindButtons) btn.RefreshUI();
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void LoadCurrentSettings()
    {
        float savedSens = PlayerPrefs.GetFloat("MouseSensitivity", 2f);
        if (sensSlider != null) sensSlider.value = savedSens;
        if (sensValueText != null) sensValueText.text = savedSens.ToString("F1");
    }

    public void SetSensitivity(float value)
    {
        float roundedValue = Mathf.Round(value * 10f) / 10f;
        PlayerPrefs.SetFloat("MouseSensitivity", roundedValue);
        if (sensValueText != null) sensValueText.text = roundedValue.ToString("F1");

        if (Player.Instance != null)
        {
            Player.Instance.UpdateSensitivity(roundedValue);
        }
    }

    public void SetVSync(bool isOn)
    {
        QualitySettings.vSyncCount = isOn ? 1 : 0;
        PlayerPrefs.SetInt("VSync", isOn ? 1 : 0);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
    }
}