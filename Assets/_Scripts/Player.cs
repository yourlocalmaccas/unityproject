using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    void Awake()
    {
        Instance = this;
    }

    [Header("Movement")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float lookSpeed = 2f;

    [Header("Interaction")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private CursorImage cursorScript;

    private float xRotation = 0f;

    public bool hasKey = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Move();
        Look();
        HandleInteraction();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        transform.position += move * speed * Time.deltaTime;
    }

    void Look()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxisRaw("Mouse Y") * lookSpeed;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleInteraction()
    {
        if (cursorScript.currentTarget != null && Input.GetKeyDown(KeyCode.E))
        {
            IInteractable interactable = cursorScript.currentTarget.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.OnInteract();
            }
        }
    }
}
