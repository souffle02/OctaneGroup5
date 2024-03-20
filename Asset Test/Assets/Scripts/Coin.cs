using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static event Action<Coin> onPlayerCollectCoinEvent;
    [SerializeField] AudioSource coinsfx;

    /*
    private void OnEnable() {
        EventScriptManager.onPlayerCollectCoinEvent += coinCollected;
    }

    private void OnDisable() {
        EventScriptManager.onPlayerCollectCoinEvent -= coinCollected;
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onPlayerCollectCoinEvent?.Invoke(this);
            coinsfx.Play();
            Destroy(gameObject); // Destroy the coin after collection
        }
    }

    /*
    private void coinCollected(EventScriptManager events) {
        Debug.Log("Player collected a coin");
    }
    */
}
