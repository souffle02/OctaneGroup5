using UnityEngine;

public class Invincibility : MonoBehaviour
{
    private float invincibleTime = 5f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().ActivateInvincibility();
            Destroy(gameObject); // Destroy the power-up
            Invoke("DeactivateInvincibility", invincibleTime);
        }
    }

    private void DeactivateInvincibility()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        print("Called");
        if (player != null)
        {
            print("b");
            player.GetComponent<PlayerController>().DeactivateInvincibility();
        }
    }
}
