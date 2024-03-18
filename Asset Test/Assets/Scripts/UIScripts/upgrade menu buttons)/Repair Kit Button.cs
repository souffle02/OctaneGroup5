using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RepairKitButton : MonoBehaviour
{
    [SerializeField] private TMP_Text repairKitEffects;
    private int upgradeLevel;
    private int maxlevel = 2;
    private bool ismaxlevel;

    private int coinsRequired;
    public static int livesRestored;
    
    // Start is called before the first frame update
    void Start()
    {
        upgradeLevel = 1;
        ismaxlevel = false;
        coinsRequired = 250;

        livesRestored = 1;  // initial lives restored is 1
        repairKitEffects.text = "Current: " + livesRestored + " life" + 
            "\nNext: " + (livesRestored + 1) + " lives" + 
            "\nCoins for next level: " + coinsRequired;
    }

    public void UpgradeRepairKit() {
        if (UpgradeMenu.coins >= coinsRequired) {
            if (!ismaxlevel) {
                upgradeLevel += 1;
                UpgradeMenu.coins -= coinsRequired;
                Debug.Log("Coins: " + UpgradeMenu.coins);

                livesRestored += 1;
                repairKitEffects.text = "Current: " + livesRestored + " lives" + 
                    "\nNext: " + (livesRestored + 1) + " lives" + 
                    "\nUpgrade cost: " + coinsRequired + " coins";
            }
            
            if (upgradeLevel == maxlevel) {
                ismaxlevel = true;
            }

            if (ismaxlevel) {
                repairKitEffects.text = "Current: " + livesRestored + " lives" + 
                        "\nMAX LEVEL";
            }
        }
    }
}
