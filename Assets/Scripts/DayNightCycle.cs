using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float dayLength = 120.0f;  
    public Light sunLight;
    private float currentTime = 50.0f;


    void Update()
    {
        
        currentTime += Time.deltaTime;
        if (currentTime >= dayLength)
        {
            currentTime = 0.0f;  
        }

        float timeOfDay = currentTime / dayLength;

        float sunRotationAngle = timeOfDay * 360.0f;

        sunLight.transform.rotation = Quaternion.Euler(new Vector3(sunRotationAngle, 30.0f, 0.0f));

        float intensity = Mathf.Clamp01(1.0f - Mathf.Abs(timeOfDay - 0.5f) * 2.0f);
        sunLight.intensity = intensity;
    }
}
