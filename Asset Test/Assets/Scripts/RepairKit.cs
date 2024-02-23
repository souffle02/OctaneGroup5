using UnityEngine;

public class RepairKit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().AddLife();
            Destroy(gameObject); // Destroy the power-up
        }
    }
}
