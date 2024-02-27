using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMultiplier : MonoBehaviour
{
    private void OnEnable() {
        EventScriptManager.onCollectCoinMultiplier += ActiveCoinMultiplier;
    }

    private void OnDisable() {
        EventScriptManager.onCollectCoinMultiplier -= ActiveCoinMultiplier;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Start the coroutine on the player's gameObject instead of the power-up
            other.gameObject.GetComponent<PlayerController>().StartCoroutine(ActivateAndDeactivateCoinMultiplier(other.GetComponent<PlayerController>()));
            Destroy(gameObject); // Destroy the power-up
        }
    }

    private void ActiveCoinMultiplier(EventScriptManager powerup) {
        Debug.Log("Coin multiplier collected");
    }

    private IEnumerator ActivateAndDeactivateCoinMultiplier(PlayerController playerController)
    {
        Debug.Log("coin multiplier activated");
        playerController.ActivateCoinMultiplier();
        yield return new WaitForSeconds(3); // Wait period for testing
        playerController.DeactivateCoinMultiplier();
        Debug.Log("coin multiplier deactivated");
    }
}
