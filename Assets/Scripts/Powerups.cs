using UnityEngine;

public class Powerups : MonoBehaviour
{
    public float bobSpeed = 2.0f;
    public float bobHeight = 2f;
    private bool isBobbingUp = true;
    private Vector3 originalPosition;

    public float speedBoostAmount = 500.0f;
    public float decreaseAmount = 5.0f;
    public Timer timez;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {
        Bob();
        transform.Rotate(Vector3.up * Time.deltaTime * 30.0f);
    }

    private void Bob()
    {
        float newY;

        if (isBobbingUp)
        {
            newY = Mathf.MoveTowards(transform.position.y, originalPosition.y + bobHeight, bobSpeed * Time.deltaTime);
            if (newY >= originalPosition.y + bobHeight - 0.01f)
            {
                isBobbingUp = false;
            }
        }
        else
        {
            newY = Mathf.MoveTowards(transform.position.y, originalPosition.y - bobHeight, bobSpeed * Time.deltaTime);
            if (newY <= originalPosition.y - bobHeight + 0.01f)
            {
                isBobbingUp = true;
            }
        }

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player2"))
        {
            if (gameObject.CompareTag("Powerup1"))
            {
                ApplySpeedBoost(speedBoostAmount);
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("Powerup2"))
            {
                timez.elapsedTime -= 10;
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("Powerup3"))
            {
                timez.elapsedTime += 10;
                Destroy(gameObject);
            }
        }
    }

    private void ApplySpeedBoost(float boostAmount)
    {
        CarController carController = GetComponent<CarController>();
        if (carController != null)
        {
            carController.ApplySpeedBoost(boostAmount);
        }
    }
}