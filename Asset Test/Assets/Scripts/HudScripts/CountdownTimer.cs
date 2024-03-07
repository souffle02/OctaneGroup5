using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TMP_Text timerText;
    private float currentTime;

    private bool isCounting = false;

    private Image powerupImage;

    [SerializeField] private Sprite multiplierSprite;
    [SerializeField] private Sprite timewarpSprite;
    [SerializeField] private Sprite invincibilitySprite;
    [SerializeField] private Sprite rocketSprite;



    private void OnEnable()
    {
        Timewarp.onPlayerCollectTimeWarpEvent += startTimeWarpCountdown;
        Invincibility.onPlayerCollectInvincibilityEvent += startInvincibilityCountdown;
        CoinMultiplier.onCollectCoinMultiplier += startMultiplierCountdown;
        // Event.onPlayerCollectCoinEvent += AddCoin;
        // TODO: might need to add an event for collecting a x2 powerup. need to create a canvas with the x2 icon
    }

    private void OnDisable()
    {
        Timewarp.onPlayerCollectTimeWarpEvent -= startTimeWarpCountdown;
        Invincibility.onPlayerCollectInvincibilityEvent -= startInvincibilityCountdown;
        CoinMultiplier.onCollectCoinMultiplier -= startMultiplierCountdown;


        // Event.onPlayerCollectCoinEvent -= AddCoin;
    }
    private void Start()
    {
        powerupImage = timerText.gameObject.GetComponentsInChildren<Image>()[0];
        // Initially hide the timer text
        timerText.enabled = false;
        powerupImage.enabled = false;
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
                timerText.enabled = false;
                powerupImage.enabled = false;
            }
        }
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
        powerupImage.enabled = true;
    }

    public void startTimeWarpCountdown(Timewarp events)
    {
        powerupImage.sprite = timewarpSprite;
        StartCountdown(5f);
    }

    public void startInvincibilityCountdown(Invincibility events)
    {
        powerupImage.sprite = invincibilitySprite;
        StartCountdown(5f);
    }

    public void startMultiplierCountdown(CoinMultiplier events)
    {
        powerupImage.sprite = multiplierSprite;
        StartCountdown(5f);
    }
}