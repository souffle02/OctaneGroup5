using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField] AudioSource sfx;
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
            sfx.Play();
            other.GetComponent<PlayerController>().EnableShooting();
            Destroy(gameObject); // Destroy the power-up
        }
    }

    private void LauncherObtained(EventScriptManager powerup) {
        Debug.Log("Rocket launcher obtained");
    }
}
