using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMultiplier : MonoBehaviour
{
    public static event Action<CoinMultiplier> onCollectCoinMultiplier;
    /*
    private void OnEnable() {
        EventScriptManager.onCollectCoinMultiplier += ActiveCoinMultiplier;
    }

    private void OnDisable() {
        EventScriptManager.onCollectCoinMultiplier -= ActiveCoinMultiplier;
    }
    */
    [SerializeField] AudioSource sfx;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onCollectCoinMultiplier?.Invoke(this);
            sfx.Play();
            // Start the coroutine on the player's gameObject instead of the power-up
            // other.gameObject.GetComponent<PlayerController>().StartCoroutine(ActivateAndDeactivateCoinMultiplier(other.GetComponent<PlayerController>())); // i dont think this is needed
            onCollectCoinMultiplier?.Invoke(this);
            Destroy(gameObject); // Destroy the power-up
        }
    }

    /* 
    private void ActiveCoinMultiplier(EventScriptManager powerup) {
        Debug.Log("Coin multiplier collected");
    }

    private IEnumerator ActivateAndDeactivateCoinMultiplier(PlayerController playerController)
    {
        Debug.Log("coin multiplier activated");
        playerController.ActivateCoinMultiplier();
        yield return new WaitForSeconds(6); // Wait period for testing
        playerController.DeactivateCoinMultiplier();
        Debug.Log("coin multiplier deactivated");
    }
    */
}
