using System;
using UnityEngine;

public class RepairKit : MonoBehaviour
{
    public static event Action<RepairKit> onCollectRepairKit;
    /*
    private void OnEnable() {
        EventScriptManager.onCollectRepairKit += CollectRepairKit;
    }

    private void OnDisable() {
        EventScriptManager.onCollectRepairKit -= CollectRepairKit;
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onCollectRepairKit?.Invoke(this);
            // other.GetComponent<PlayerController>().AddLife();
            Destroy(gameObject); // Destroy the power-up
        }
    }

    /*
    private void CollectRepairKit(EventScriptManager powerup) {
        Debug.Log("Repair kit collected");
    }
    */
}
