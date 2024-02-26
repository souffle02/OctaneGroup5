using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timewarp : MonoBehaviour
{
    /* 
    Timewarp powerup will grant the player increased turning maneuverability, allowing them to 
    make much tighter turns than they normally would. Additionally, playing speed will be reduced
    by 25-30%, giving the player more time to react to oncoming obstacles.
    */
    private void OnEnable() {
        PowerupCollectionManager.onCollectInvincibility += ActiveTimewarp;
    }

    private void OnDisable() {
        PowerupCollectionManager.onCollectInvincibility -= ActiveTimewarp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Start the coroutine on the player's gameObject instead of the power-up
            other.gameObject.GetComponent<PlayerController>().StartCoroutine(ActivateAndDeactivateTimewarp(other.GetComponent<PlayerController>()));
            Destroy(gameObject); // Destroy the power-up
        }
    }

    private void ActiveTimewarp(PowerupCollectionManager powerup) {
        Debug.Log("Timewarp collected");
    }

    private IEnumerator ActivateAndDeactivateTimewarp(PlayerController playerController)
    {
        Debug.Log("activated");
        playerController.ActivateTimewarp();
        yield return new WaitForSeconds(10); // Wait for 10 seconds
        Debug.Log("waited");
        playerController.DeactivateTimewarp();
    }
}
