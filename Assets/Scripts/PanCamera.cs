using UnityEngine;

public class PanCamera : MonoBehaviour
{
    public float rotationSpeed = 20f;
    private Transform cameraTransform;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        cameraTransform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}