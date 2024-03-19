using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimerMain : MonoBehaviour
{
     [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;
    
   
    void Update(){
        elapsedTime += Time.deltaTime;
        double minutes = Mathf.FloorToInt(elapsedTime / 60);
        double seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = String.Format("{0:00}:{1:00}",minutes, seconds);

    }
}