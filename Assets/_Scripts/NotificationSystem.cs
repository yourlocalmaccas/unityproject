using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class NotificationSystem : MonoBehaviour
{
    public static NotificationSystem Instance;

    [SerializeField] private TextMeshProUGUI textElement;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float typingSpeed = 0.05f;

    private Coroutine activeRoutine;

    void Awake()
    {
        Instance = this;
        canvasGroup.alpha = 0; 
    }

    public void ShowNotification(object message, float lifetime = 3f)
    {
        if (activeRoutine != null) StopCoroutine(activeRoutine);
        activeRoutine = StartCoroutine(TypeWriterEffect(message.ToString(), lifetime));
    }

    private IEnumerator TypeWriterEffect(string fullText, float lifetime)
    {
        canvasGroup.alpha = 1;
        textElement.text = "";

        foreach (char letter in fullText.ToCharArray())
        {
            textElement.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        yield return new WaitForSeconds(lifetime);

        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * 2f;
            yield return null;
        }
    }
}