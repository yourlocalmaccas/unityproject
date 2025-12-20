using UnityEngine;

public class HeadBob : MonoBehaviour
{

    [SerializeField] private float bobFrequency = 1.5f;      // How fast the bob happens
    [SerializeField] private float bobHorizontalAmplitude = 0.05f;  // Left-right sway
    [SerializeField] private float bobVerticalAmplitude = 0.08f;    // Up-down movement
    [SerializeField] private float bobSmoothing = 10f;       // How smooth the transition is

  
    [SerializeField] private Transform cameraTransform;      

    private Vector3 targetCameraPosition;
    private Vector3 initialCameraPosition;
    private float bobTimer = 0f;

    void Start()
    {
        initialCameraPosition = cameraTransform.localPosition;
        targetCameraPosition = initialCameraPosition;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        bool isMoving = Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f;

        if (isMoving)
        {
            bobTimer += Time.deltaTime * bobFrequency;

            float horizontalOffset = Mathf.Sin(bobTimer) * bobHorizontalAmplitude;
            float verticalOffset = Mathf.Sin(bobTimer * 2f) * bobVerticalAmplitude; 

            targetCameraPosition = initialCameraPosition + new Vector3(horizontalOffset, verticalOffset, 0f);
        }
        else
        {
            bobTimer = 0f;
            targetCameraPosition = initialCameraPosition;
        }

        cameraTransform.localPosition = Vector3.Lerp(
            cameraTransform.localPosition,
            targetCameraPosition,
            Time.deltaTime * bobSmoothing
        );
    }


}