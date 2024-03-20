using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RepairKitButton : MonoBehaviour
{
    [SerializeField] private TMP_Text repairKitEffects;
    public static RepairKitButton repairKitInstance;

    private static int upgradeLevel = 1;
    private int maxlevel = 2;
    private static bool ismaxlevel = false;

    private static int coinsRequired = 175;
    public static int livesRestored = 1;

    public void Awake() {
        if (repairKitInstance == null) {
            repairKitInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (ismaxlevel) {
            repairKitEffects.text = "Current: " + livesRestored + " lives" + 
                    "\nMAX LEVEL";
        } else {
            repairKitEffects.text = "Current: " + livesRestored + " life" + 
                "\nNext: " + (livesRestored + 1) + " lives" + 
                "\nCoins for next level: " + coinsRequired;
        }
    }

    public void UpgradeRepairKit() {
        if (UpgradeMenu.coins >= coinsRequired) {
            if (!ismaxlevel) {
                upgradeLevel += 1;
                UpgradeMenu.coins -= coinsRequired;
                // Debug.Log("Coins: " + UpgradeMenu.coins);

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
