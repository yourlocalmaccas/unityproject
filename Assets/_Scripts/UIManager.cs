using UnityEngine;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI statusText;
    public GameObject textBackground;

    [Header("Typing Settings")]
    [SerializeField] private float typingSpeed = 0.05f;

    private void Start()
    {
        if (textBackground != null)
            textBackground.SetActive(false);
    }

    public void ShowStatus(string message, float stayDuration)
    {
        Debug.Log("ShowStatus called with message: " + message);
        StopAllCoroutines();
        StartCoroutine(TypeText(message, stayDuration));
    }

    private IEnumerator TypeText(string message, float stayDuration)
    {
        if (textBackground != null)
            textBackground.SetActive(true);

        if (statusText != null)
        {
            statusText.text = message;
            statusText.maxVisibleCharacters = 0;
        }

        for (int i = 0; i <= message.Length; i++)
        {
            if (statusText != null)
                statusText.maxVisibleCharacters = i;

            yield return new WaitForSeconds(typingSpeed);
        }

        yield return new WaitForSeconds(stayDuration);

        if (textBackground != null)
            textBackground.SetActive(false);
    }
}