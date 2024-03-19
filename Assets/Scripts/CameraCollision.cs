using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 2f;
    public float maxPitch = 60f;
    public float minPitch = -30f;
    public float minDistance = 2f;
    public float maxDistance = 10f;
    public float zoomSpeed = 2f;

    private Vector3 previousMousePosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            previousMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 mouseDelta = Input.mousePosition - previousMousePosition;
            RotateCameraAroundCar(mouseDelta);
            previousMousePosition = Input.mousePosition;
        }

        ZoomCamera();
    }

    void RotateCameraAroundCar(Vector3 mouseDelta)
    {
        float rotationX = mouseDelta.y * rotationSpeed;
        float rotationY = -mouseDelta.x * rotationSpeed;

        float currentPitch = transform.eulerAngles.x;
        float newPitch = Mathf.Clamp(currentPitch + rotationX, minPitch, maxPitch);
        transform.eulerAngles = new Vector3(newPitch, transform.eulerAngles.y, 0f);

        transform.RotateAround(player.position, Vector3.up, rotationY);
    }

    void ZoomCamera()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float distance = Vector3.Distance(transform.position, player.position);

        distance = Mathf.Clamp(distance - scroll * zoomSpeed, minDistance, maxDistance);

        transform.position = player.position - transform.forward * distance;
    }
}