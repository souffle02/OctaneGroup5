using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lore : MonoBehaviour
{
    public static event Action<Lore> onPlayerCollectLogEvent;

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
            onPlayerCollectLogEvent?.Invoke(this);
            Destroy(gameObject); // Destroy the lore book after collection
        }
    }

    /*
    private void coinCollected(EventScriptManager events) {
        Debug.Log("Player collected a coin");
    }
    */
}
