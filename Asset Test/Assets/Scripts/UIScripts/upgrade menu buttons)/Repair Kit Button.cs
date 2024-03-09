using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RepairKitButton : MonoBehaviour
{
    [SerializeField] private TMP_Text repairKitEffects;
    private int livesRestored;
    
    // Start is called before the first frame update
    void Start()
    {
        livesRestored = 1;  // initial lives restored is 1
        repairKitEffects.text = "Current: " + livesRestored + " life" + 
            "\nNext: " + (livesRestored + 1) + " lives";
    }

    public void UpgradeRepairKit() {
        livesRestored += 1;
        repairKitEffects.text = "Current: " + livesRestored + " lives" + 
            "\nNext: " + (livesRestored + 1) + " lives";
    }
}
