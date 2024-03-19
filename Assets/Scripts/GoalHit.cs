using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalHit : MonoBehaviour
{
    public int goalpostIndex;
    public Timer timer;
    private bool hasBeenHit = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Player2") && !hasBeenHit)
        {
            timer.elapsedTime += 15;
            hasBeenHit = true;
        }
    }
}