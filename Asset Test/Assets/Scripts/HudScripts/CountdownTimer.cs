using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TMP_Text timerText;
    private float currentTime;

    private bool isCounting = false;

    private void OnEnable()
    {
        Timewarp.onPlayerCollectTimeWarpEvent += startTimeWarpCountdown;
        // Event.onPlayerCollectCoinEvent += AddCoin;
        // TODO: might need to add an event for collecting a x2 powerup. need to create a canvas with the x2 icon
    }

    private void OnDisable()
    {
        Timewarp.onPlayerCollectTimeWarpEvent -= startTimeWarpCountdown;
        // Event.onPlayerCollectCoinEvent -= AddCoin;
    }
    private void Start()
    {
        // Initially hide the timer text
        timerText.enabled = false;
    }

    private void Update()
    {
        if (isCounting)
        {
            currentTime -= Time.deltaTime / Time.timeScale;
            UpdateTimerDisplay();

            if (currentTime <= 0f)
            {
                // Timer finished, reset
                currentTime = 0f;
                isCounting = false;
                timerText.enabled = true;
            }
        }else{timerText.enabled = false;}
    }

    void UpdateTimerDisplay()
    {
        // Display time in seconds
        timerText.SetText(Mathf.CeilToInt(currentTime).ToString());
    }

    public void StartCountdown(float duration)
    {
        // Start the countdown with the specified duration
        Debug.Log("STARTING COUNTDOWN");
        currentTime = duration;
        isCounting = true;
        timerText.enabled = true;
    }

    public void startTimeWarpCountdown(Timewarp events)
    {
        StartCountdown(5f);
    }
}