using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    private void OnEnable() {
        PowerupCollectionManager.onCollectRocketLauncher += LauncherObtained;
    }

    private void OnDisable() {
        PowerupCollectionManager.onCollectRocketLauncher -= LauncherObtained;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().EnableShooting();
            Destroy(gameObject); // Destroy the power-up
        }
    }

    private void LauncherObtained(PowerupCollectionManager powerup) {
        Debug.Log("Rocket launcher obtained");
    }
}
