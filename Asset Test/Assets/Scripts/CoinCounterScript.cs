using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCounterScript : MonoBehaviour
{
    [SerializeField] private TMP_Text coinCounter;
    public static CoinCounterScript CoinsInstance;
    public int coinCount = 0;
    private Boolean doubleCoin = false;

    // TODO: add double coin logic and to HUD
    // PlayerController collectibleCount = FindObjectOfType<PlayerController>(); // probably dont need this.

    private void OnEnable()
    {
        Coin.onPlayerCollectCoinEvent += AddCoin;
        CoinMultiplier.onCollectCoinMultiplier += DoubleCoinTimer;
        // Event.onPlayerCollectCoinEvent += AddCoin;
        // TODO: might need to add an event for collecting a x2 powerup. need to create a canvas with the x2 icon
    }

    private void OnDisable()
    {
        Coin.onPlayerCollectCoinEvent -= AddCoin;
        CoinMultiplier.onCollectCoinMultiplier -= DoubleCoinTimer;
        // Event.onPlayerCollectCoinEvent -= AddCoin;
    }

    public void Awake()
    {
        CoinsInstance = this;
    }
    private void Start()
    {
        
        coinCounter.SetText(coinCount.ToString());
    }

    /*
    public void UpdateCoins()
    {
        coinCount = collectibleCount.coins;
        coinCounter.SetText(coinCount.ToString());
    }
    */

    public void AddCoin(Coin events) // argument should be EventScript event
    {
        Debug.Log("Coin collection event heard");
        if(doubleCoin)
        {
            coinCount += 2;
        }
        else
        {
            coinCount++;
        }

        coinCounter.SetText(coinCount.ToString());
    }

    public void DoubleCoinTimer(CoinMultiplier events) {
        doubleCoin = true;
        Debug.Log("double coin activated");
        StartCoroutine(ResetDoubleCoin());
    }

    private IEnumerator ResetDoubleCoin()
    {
        yield return new WaitForSeconds(5f); // Wait for 5 seconds
        doubleCoin = false; // Reset doubleCoin to false
        Debug.Log("double coin deactivated");
    }
}
