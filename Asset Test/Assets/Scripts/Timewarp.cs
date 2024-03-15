using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timewarp : MonoBehaviour
{
    /* 
    Timewarp powerup will grant the player increased turning maneuverability, allowing them to 
    make much tighter turns than they normally would. Additionally, playing speed will be reduced
    by 25-30%, giving the player more time to react to oncoming obstacles.
    */

    private float timeSlowDownAmount = 0.5f; //1 = normal

    public Image timeWarpEffectHue;

    public static event Action<Timewarp> onPlayerCollectTimeWarpEvent;


    private void OnEnable() {
        timeWarpEffectHue.enabled = false;
        // EventScriptManager.onCollectInvincibility += ActiveTimewarp;
    }

    private void OnDisable() {
        // EventScriptManager.onCollectInvincibility -= ActiveTimewarp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Start the coroutine on the player's gameObject instead of the power-up
            onPlayerCollectTimeWarpEvent?.Invoke(this);
            other.gameObject.GetComponent<PlayerController>().StartCoroutine(ActivateAndDeactivateTimewarp(other.GetComponent<PlayerController>()));
            Destroy(gameObject); // Destroy the power-up
        }
    }

    private void ActiveTimewarp(EventScriptManager powerup) {
        Debug.Log("Timewarp collected");
    }

    private IEnumerator ActivateAndDeactivateTimewarp(PlayerController playerController)
    {
        Debug.Log("timewarp activated, hue: " + timeWarpEffectHue.enabled);


        // Slow down time
        timeWarpEffectHue.enabled = true;
        Debug.Log(" hue: " + timeWarpEffectHue.enabled);
        Time.timeScale = timeSlowDownAmount;
        Time.fixedDeltaTime = 0.02f * Time.timeScale; // Adjust fixedDeltaTime according to the time scale
        

        yield return new WaitForSecondsRealtime(5); // Wait for 5 seconds in real-time, not game time

        // Return time to normal speed
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02f; // Reset fixedDeltaTime to the default value
        timeWarpEffectHue.enabled = false;

        Debug.Log("timewarp deactivated");
    }
}
