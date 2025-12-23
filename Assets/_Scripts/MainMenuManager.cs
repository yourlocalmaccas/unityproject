using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject helpPanel; 

    public void OnPlayButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnQuitButton()
    {
        Debug.Log("Game is exiting...");
        Application.Quit();
    }

    //public void ToggleHelp(bool show)
    //{
        //if (helpPanel != null)
        //{
           // helpPanel.SetActive(show);
        //}
//}
}