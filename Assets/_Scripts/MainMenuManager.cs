using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public Slider sensSlider;
    public TMP_Text sensValueText;
    private bool isPaused = false;

    private void Start()
    {
        if (settingsPanel != null) settingsPanel.SetActive(false);
        LoadSettings();
    }

    void LoadSettings()
    {
        float savedSens = PlayerPrefs.GetFloat("MouseSensitivity", 2f);
        if (sensSlider != null) sensSlider.value = savedSens;
        if (sensValueText != null) sensValueText.text = savedSens.ToString("F1");

        QualitySettings.vSyncCount = PlayerPrefs.GetInt("VSync", 1);
        Screen.fullScreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
    }

    public void Update()
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
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void SetVSync(bool isOn)
    {
        QualitySettings.vSyncCount = isOn ? 1 : 0;
        PlayerPrefs.SetInt("VSync", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void SetSensitivity(float value)
    {
        float roundedValue = Mathf.Round(value * 10f) / 10f;
        PlayerPrefs.SetFloat("MouseSensitivity", roundedValue);
        if (sensValueText != null) sensValueText.text = roundedValue.ToString("F1");
        PlayerPrefs.Save();
        
        if(Player.Instance != null)
        {
            Player.Instance.UpdateSensitivity(roundedValue);
        }
    }
}