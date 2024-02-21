using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCounterScript : MonoBehaviour
{
    [SerializeField] private TMP_Text coinCounter;
    private int coinCount = 0;
    private bool coinsDoubled;

    private void OnEnable()
    {
        EventScriptManager.onPlayerCollectCoinEvent += AddCoin;
        PowerupCollectionManager.onCollectCoinMultiplier += ActiveCoinMultiplier;
        // Event.onPlayerCollectCoinEvent += AddCoin;
        // TODO: might need to add an event for collecting a x2 powerup. need to create a canvas with the x2 icon
    }

    private void OnDisable()
    {
        EventScriptManager.onPlayerCollectCoinEvent -= AddCoin;
        PowerupCollectionManager.onCollectCoinMultiplier -= ActiveCoinMultiplier;
        // Event.onPlayerCollectCoinEvent -= AddCoin;
    }

    private void Start()
    {
        coinCounter.SetText(coinCount.ToString());
        coinsDoubled = false;
    }

    private void AddCoin(EventScriptManager events) // argument should be EventScript event
    {
        Debug.Log("Coin collection event heard");
        coinCount++;
        if (coinsDoubled == true) {
            coinCount++;
        }
        coinCounter.SetText(coinCount.ToString());
    }

    private void ActiveCoinMultiplier(PowerupCollectionManager powerup) {
        Debug.Log("Coin multiplier active");
        coinsDoubled = true;
    }
}
