using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAntiFlipper : MonoBehaviour
{
    public WheelCollider rearLeftWheel, rearRightWheel;
    public float AntiFlip = 5000.0f;

    public Rigidbody car;

    private void Start()
    {
        car = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        WheelHit hit;
        float leftTravel = 1.0f;
        float rightTravel = 1.0f;

        bool isGroundedLeft = rearLeftWheel.GetGroundHit(out  hit);
        if(isGroundedLeft)
        {
            leftTravel = (rearLeftWheel.transform.InverseTransformPoint(hit.point).y - rearLeftWheel.radius) / rearLeftWheel.suspensionDistance;
        }
        bool isGroundedRight = rearRightWheel.GetGroundHit(out hit);
        if(isGroundedRight) {
            rightTravel = (rearRightWheel.transform.InverseTransformPoint(hit.point).y - rearRightWheel.radius) / rearRightWheel.suspensionDistance;
        }

        float antiFlipForce = (leftTravel - rightTravel) * AntiFlip;

        if (isGroundedLeft)
        {
            car.AddForceAtPosition(rearLeftWheel.transform.up * -antiFlipForce, rearLeftWheel.transform.position);
        }
        if (isGroundedRight)
        {
            car.AddForceAtPosition(rearRightWheel.transform.up * antiFlipForce, rearRightWheel.transform.position);
        }
    }
}
