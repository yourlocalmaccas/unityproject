using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 
    
    public int coinCounter;
    public bool wonGame;

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (coinCounter >= 3 && !wonGame)
        {
            wonGame = true;
            Debug.Log("You Win!");
            SceneManager.LoadScene("EndScene");
        }
    }
}