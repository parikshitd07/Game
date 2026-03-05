using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Settings")]
    public Transform target; // Center of the room
    public float distance = 10f;
    public float rotationSpeed = 5f;
    public float zoomSpeed = 2f;
    public float minDistance = 5f;
    public float maxDistance = 20f;

    [Header("Mouse Controls")]
    public bool enableMouseRotation = true;
    public bool enableMouseZoom = true;

    private float currentRotationY = 0f;
    private float currentRotationX = 30f;

    void Start()
    {
        if (target == null)
        {
            // Create target at room center if not assigned
            GameObject targetObj = new GameObject("CameraTarget");
            target = targetObj.transform;
            target.position = Vector3.zero;
        }

        UpdateCameraPosition();
    }

    void Update()
    {
        HandleMouseRotation();
        HandleMouseZoom();
        HandleKeyboardRotation();
        
        UpdateCameraPosition();
    }

    void HandleMouseRotation()
    {
        if (enableMouseRotation && Input.GetMouseButton(2)) // Middle mouse button
        {
            currentRotationY += Input.GetAxis("Mouse X") * rotationSpeed;
            currentRotationX -= Input.GetAxis("Mouse Y") * rotationSpeed;
            currentRotationX = Mathf.Clamp(currentRotationX, 5f, 85f);
        }
    }

    void HandleMouseZoom()
    {
        if (enableMouseZoom)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            distance -= scroll * zoomSpeed;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);
        }
    }

    void HandleKeyboardRotation()
    {
        // Q/E for rotation
        if (Input.GetKey(KeyCode.Q))
        {
            currentRotationY -= rotationSpeed * Time.deltaTime * 20f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            currentRotationY += rotationSpeed * Time.deltaTime * 20f;
        }

        // Arrow keys for rotation
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentRotationY -= rotationSpeed * Time.deltaTime * 20f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentRotationY += rotationSpeed * Time.deltaTime * 20f;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            currentRotationX -= rotationSpeed * Time.deltaTime * 20f;
            currentRotationX = Mathf.Clamp(currentRotationX, 5f, 85f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            currentRotationX += rotationSpeed * Time.deltaTime * 20f;
            currentRotationX = Mathf.Clamp(currentRotationX, 5f, 85f);
        }
    }

    void UpdateCameraPosition()
    {
        if (target == null) return;

        Quaternion rotation = Quaternion.Euler(currentRotationX, currentRotationY, 0);
        Vector3 offset = rotation * Vector3.back * distance;
        
        transform.position = target.position + offset;
        transform.LookAt(target.position);
    }

    public void ResetCamera()
    {
        currentRotationY = 0f;
        currentRotationX = 30f;
        distance = 10f;
        UpdateCameraPosition();
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
