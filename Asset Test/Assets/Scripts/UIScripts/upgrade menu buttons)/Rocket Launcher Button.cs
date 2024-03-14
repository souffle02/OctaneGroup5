using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RocketLauncherUpgrade : MonoBehaviour
{
    [SerializeField] private TMP_Text rocketLauncherEffects;
    private int upgradeLevel;
    private int maxlevel = 4;
    private bool ismaxlevel;

    private int coinsRequired;
    private int rockets;
    
    // Start is called before the first frame update
    void Start()
    {
        upgradeLevel = 1;
        ismaxlevel = false;
        coinsRequired = 45;

        rockets = 1;  // initial number of rockets stored is 1, can be upgraded to store up to 3
        rocketLauncherEffects.text = "Current: " + rockets + " rockets" + 
            "\nNext: " + (rockets + 1) + " rockets" + 
            "\nUpgrade cost: " + coinsRequired + " coins";
    }

    public void UpgradeRocketLauncher() {
        if (UpgradeMenu.coins >= coinsRequired) {
            if (!ismaxlevel) {
                upgradeLevel += 1;
                UpgradeMenu.coins -= coinsRequired;
                Debug.Log("Coins: " + UpgradeMenu.coins);

                rockets += 1;
                coinsRequired += (coinsRequired / 9) + 8;
                rocketLauncherEffects.text = "Current: " + rockets + " seconds" + 
                    "\nNext: " + (rockets + 1) + " seconds" + 
                    "\nUpgrade cost: " + coinsRequired + " coins";
            }
            
            if (upgradeLevel == maxlevel) {
                ismaxlevel = true;
            }

            if (ismaxlevel) {
                rocketLauncherEffects.text = "Current: " + rockets + " seconds" + 
                        "\nMAX LEVEL";
            }
        }
    }
}
