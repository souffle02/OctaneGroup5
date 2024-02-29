using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnEnable() {
        EventScriptManager.onPlayerCollectCoinEvent += coinCollected;
    }

    private void OnDisable() {
        EventScriptManager.onPlayerCollectCoinEvent -= coinCollected;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().AddCoin();
            Destroy(gameObject); // Destroy the coin after collection
        }
    }

    private void coinCollected(EventScriptManager events) {
        Debug.Log("Player collected a coin");
    }
}
