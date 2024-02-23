using UnityEngine;

public class RepairKit : MonoBehaviour
{
    private void OnEnable() {
        PowerupCollectionManager.onCollectRepairKit += CollectRepairKit;
    }

    private void OnDisable() {
        PowerupCollectionManager.onCollectRepairKit -= CollectRepairKit;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().AddLife();
            Destroy(gameObject); // Destroy the power-up
        }
    }

    private void CollectRepairKit(PowerupCollectionManager powerup) {
        Debug.Log("Repair kit collected");
    }
}
