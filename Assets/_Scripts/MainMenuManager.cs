using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject mainPanel;
    public Slider sensSlider;
    public TMP_Text sensValueText;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;

        if (settingsPanel != null) settingsPanel.SetActive(false);
        if (mainPanel != null) mainPanel.SetActive(true);
        
        if (sensSlider != null)
        {
            sensSlider.minValue = 0.1f;
            sensSlider.maxValue = 3.0f;
        }
        
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

    public void OpenSettings()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(true);
            if (mainPanel != null) mainPanel.SetActive(false);

            KeyBindButton[] rebindButtons = settingsPanel.GetComponentsInChildren<KeyBindButton>();
            foreach (var btn in rebindButtons) btn.RefreshUI();
        }
    }

    public void CloseSettings()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
            if (mainPanel != null) mainPanel.SetActive(true);
        }
    }

    public void OnPlayButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnQuitButton()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
    private void Awake()
{
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
}
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsPanel != null && settingsPanel.activeSelf)
            {
                CloseSettings();
            }
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
    }
}