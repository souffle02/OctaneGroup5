using UnityEngine;
using System.Collections;

public class Invincibility : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Start the coroutine on the player's gameObject instead of the power-up
            other.gameObject.GetComponent<PlayerController>().StartCoroutine(ActivateAndDeactivateInvincibility(other.GetComponent<PlayerController>()));
            Destroy(gameObject); // Destroy the power-up
        }
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
