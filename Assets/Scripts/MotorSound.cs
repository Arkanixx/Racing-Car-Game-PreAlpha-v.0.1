using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorSound : MonoBehaviour
{
    public float minVelocity, maxVelocity;
    private float currentVelocity;

    private Rigidbody carBody;
    private AudioSource carSound;

    public float lowPitch, highPitch;
    private float carPitch;

    private void Start()
    {
        carBody = GetComponent<Rigidbody>();
        carSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        EngineSound();
    }

    void EngineSound()
    {
        currentVelocity = carBody.velocity.magnitude;
        carPitch = carBody.velocity.magnitude / 50f;

        if (currentVelocity < minVelocity) 
        {
            carSound.pitch = lowPitch;

        }
        if (currentVelocity > minVelocity && currentVelocity < maxVelocity)
        {
            carSound.pitch = lowPitch + carPitch;
        }

        if (currentVelocity > maxVelocity) 
        {
            carSound.pitch = highPitch;
        }
    }


}
