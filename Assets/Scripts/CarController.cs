using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput, verticalInput, currentBreakF, steeringAngle, currentSteeringAngle;
    private bool breaking;

    [SerializeField] private float motorF;
    [SerializeField] private float breakF;
    [SerializeField] private float maxSteeringAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransformr;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    private void FixedUpdate()
    {
        GetUserInput();
        HandleSteering();
        HandleMotor();
        UpdateWheelsVisuals();
    }

    private void GetUserInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        breaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleSteering()
    {
        currentSteeringAngle = maxSteeringAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteeringAngle;
        frontRightWheelCollider.steerAngle = currentSteeringAngle;
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorF;
        frontRightWheelCollider.motorTorque = verticalInput * motorF;
        currentBreakF = breaking ? breakF : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        frontLeftWheelCollider.brakeTorque = currentBreakF;
        frontRightWheelCollider.brakeTorque = currentBreakF;
        rearLeftWheelCollider.brakeTorque = currentBreakF;
        rearRightWheelCollider.brakeTorque = currentBreakF;
    }

    private void UpdateWheelsVisuals()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransformr);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider WheelCollider, Transform WheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        WheelCollider.GetWorldPose(out pos, out rot);
        WheelTransform.rotation = rot;
        WheelTransform.position = pos;
    }

    // Add this method to apply speed boost
    public void ApplySpeedBoost(float boostAmount)
    {
        // Increase the motor force by the specified boost amount
        motorF += boostAmount;
    }
}