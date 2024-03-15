using UnityEngine;
using System.Collections;
using System;

public class Invincibility : MonoBehaviour
{

    public static event Action<Invincibility> onPlayerCollectInvincibilityEvent;

    private float timeInvincible = 5;
    // may add the invincibility event triggers here depending on what group decides
    private void OnEnable() {
        // EventScriptManager.onCollectInvincibility += ActiveInvincibility;
    }

    private void OnDisable() {
        // EventScriptManager.onCollectInvincibility -= ActiveInvincibility;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onPlayerCollectInvincibilityEvent?.Invoke(this);
            // Start the coroutine on the player's gameObject instead of the power-up
            other.gameObject.GetComponent<PlayerController>().StartCoroutine(ActivateAndDeactivateInvincibility(other.GetComponent<PlayerController>()));
            Destroy(gameObject); // Destroy the power-up
        }
    }

    private void ActiveInvincibility(EventScriptManager powerup) {
        Debug.Log("Invincibility powerup collected");
    }

    private void setTimeInvincible(float time) {
        timeInvincible = time;
    }

    private IEnumerator ActivateAndDeactivateInvincibility(PlayerController playerController)
    {
        Debug.Log("invinciblity activated");
        playerController.ActivateInvincibility();
        yield return new WaitForSeconds(timeInvincible); // wait for deactivate testing
        playerController.DeactivateInvincibility();
        Debug.Log("invinciblity deactivated");
    }
}
