using UnityEngine;

public class RepairKit : MonoBehaviour
{
    private void OnEnable() {
        EventScriptManager.onCollectRepairKit += CollectRepairKit;
    }

    private void OnDisable() {
        EventScriptManager.onCollectRepairKit -= CollectRepairKit;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().AddLife();
            Destroy(gameObject); // Destroy the power-up
        }
    }

    private void CollectRepairKit(EventScriptManager powerup) {
        Debug.Log("Repair kit collected");
    }
}
