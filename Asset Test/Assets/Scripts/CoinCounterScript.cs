using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCounterScript : MonoBehaviour
{
    [SerializeField] private TMP_Text coinCounter;
    private int coinCount = 0;

    private void OnEnable()
    {
        EventScriptManager.onPlayerCollectCoinEvent += AddCoin;
        // Event.onPlayerCollectCoinEvent += AddCoin;
        // TODO: might need to add an event for collecting a x2 powerup. need to create a canvas with the x2 icon
    }

    private void OnDisable()
    {
        EventScriptManager.onPlayerCollectCoinEvent -= AddCoin;
        // Event.onPlayerCollectCoinEvent -= AddCoin;
    }

    private void Start()
    {
        coinCounter.SetText(coinCount.ToString());
    }

    private void AddCoin(EventScriptManager events) // argument should be EventScript event
    {
        Debug.Log("Coin collection event heard");
        coinCount++;
        coinCounter.SetText(coinCount.ToString());
    }
}
