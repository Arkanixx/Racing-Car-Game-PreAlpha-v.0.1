using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public float totalTime = 30f;
    public float elapsedTime;
    bool isCountingDown = true;

    void Update()
    {
        if (isCountingDown)
        {
            elapsedTime -= Time.deltaTime;

            if (elapsedTime <= 0)
            {
                elapsedTime = 0;
                isCountingDown = false;
                LoadMainMenuScene();
            }

            double minutes = Mathf.FloorToInt(elapsedTime / 60);
            double seconds = Mathf.FloorToInt(elapsedTime % 60);
            timerText.text = String.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    void Start()
    {
        elapsedTime = totalTime;
    }

    void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}