using UnityEngine;
using UnityEngine.UI;

public class CursorImage : MonoBehaviour
{
    public static CursorImage instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    [SerializeField] private Image cursorImage;
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite interactSprite;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float rayDistance = 5f;

    [HideInInspector] public GameObject currentTarget;


    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                cursorImage.sprite = interactSprite;
                currentTarget = hit.collider.gameObject;
            }
            else
            {
                cursorImage.sprite = normalSprite;
                currentTarget = null;
            }
        }
        else
        {
            cursorImage.sprite = normalSprite;
            currentTarget = null;
        }

        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * rayDistance, Color.red);
    }
}
