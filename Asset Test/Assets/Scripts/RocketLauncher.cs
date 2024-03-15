using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    private void OnEnable() {
        EventScriptManager.onCollectRocketLauncher += LauncherObtained;
    }

    private void OnDisable() {
        EventScriptManager.onCollectRocketLauncher -= LauncherObtained;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().EnableShooting();
            Destroy(gameObject); // Destroy the power-up
        }
    }

    private void LauncherObtained(EventScriptManager powerup) {
        Debug.Log("Rocket launcher obtained");
    }
}
