using UnityEngine;
using System.Collections;

public class Invincibility : MonoBehaviour
{
    // may add the invincibility event triggers here depending on what group decides
    private void OnEnable() {
        PowerupCollectionManager.onCollectInvincibility += ActiveInvincibility;
    }

    private void OnDisable() {
        PowerupCollectionManager.onCollectInvincibility -= ActiveInvincibility;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Start the coroutine on the player's gameObject instead of the power-up
            other.gameObject.GetComponent<PlayerController>().StartCoroutine(ActivateAndDeactivateInvincibility(other.GetComponent<PlayerController>()));
            Destroy(gameObject); // Destroy the power-up
        }
    }

    private void ActiveInvincibility(PowerupCollectionManager powerup) {
        Debug.Log("Invincibility powerup collected");
    }

    private IEnumerator ActivateAndDeactivateInvincibility(PlayerController playerController)
    {
        Debug.Log("activated");
        playerController.ActivateInvincibility();
        yield return new WaitForSeconds(5); // Wait for 5 seconds
        Debug.Log("waited");
        playerController.DeactivateInvincibility();
    }
}
