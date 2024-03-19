using UnityEngine;

public class MovementNew : MonoBehaviour
{
    public Transform orientation;
    public float moveSpeed = 10f;
    public float rotationSpeed = 100f;
    public float deceleration = 5f;

    private Rigidbody rb;
    private bool isDecelerating = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 moveDirection = orientation.forward * verticalInput;
        Vector3 rotateDirection = orientation.up * horizontalInput;

        if (verticalInput == 0f && horizontalInput == 0f)
        {
            isDecelerating = true;
        }
        else
        {
            isDecelerating = false;
        }

        Move(moveDirection);
        Rotate(rotateDirection);
    }

    void FixedUpdate()
    {
        if (isDecelerating)
        {
            Decelerate();
        }
    }

    void Move(Vector3 moveDirection)
    {
        rb.AddForce(moveDirection * moveSpeed);
    }

    void Rotate(Vector3 rotateDirection)
    {
        Quaternion deltaRotation = Quaternion.Euler(rotateDirection * rotationSpeed * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    void Decelerate()
    {
        Vector3 oppositeForce = -rb.velocity * deceleration;
        rb.AddForce(oppositeForce);
    }
}