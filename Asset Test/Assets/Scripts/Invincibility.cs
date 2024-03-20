using UnityEngine;
using System.Collections;
using System;

public class Invincibility : MonoBehaviour
{

    public static event Action<Invincibility> onPlayerCollectInvincibilityEvent;
    [SerializeField] AudioSource sfx;


    private float timeInvincible;
    // may add the invincibility event triggers here depending on what group decides
    
    public void Update() {
        timeInvincible = InvincibilityButton.InvincibilityDuration;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sfx.Play();

            onPlayerCollectInvincibilityEvent?.Invoke(this);
            // Start the coroutine on the player's gameObject instead of the power-up
            other.gameObject.GetComponent<PlayerController>().StartCoroutine(ActivateAndDeactivateInvincibility(other.GetComponent<PlayerController>()));
            Destroy(gameObject); // Destroy the power-up
        }
    }

    private void ActiveInvincibility(EventScriptManager powerup) {
        Debug.Log("Invincibility powerup collected");
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
