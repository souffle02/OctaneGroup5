using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RocketLauncherButton : MonoBehaviour
{
    [SerializeField] private TMP_Text rocketLauncherEffects;
    public static RocketLauncherButton launcherInstance;

    private static int upgradeLevel = 1;
    private int maxlevel = 4;
    private static bool ismaxlevel = false;

    private static int coinsRequired = 30;
    public static int rockets = 1;

    public void Awake() {
        if (launcherInstance == null) {
            launcherInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (ismaxlevel) {
            rocketLauncherEffects.text = "Current: " + rockets + " rockets" + 
                    "\nMAX LEVEL";
        } else {
            rocketLauncherEffects.text = "Current: " + rockets + " rockets" + 
                "\nNext: " + (rockets + 1) + " rockets" + 
                "\nUpgrade cost: " + coinsRequired + " coins";
        }
    }

    public void UpgradeRocketLauncher() {
        if (UpgradeMenu.coins >= coinsRequired) {
            if (!ismaxlevel) {
                upgradeLevel += 1;
                UpgradeMenu.coins -= coinsRequired;
                // Debug.Log("Coins: " + UpgradeMenu.coins);

                rockets += 1;
                coinsRequired += (coinsRequired / 9) + 8;
                rocketLauncherEffects.text = "Current: " + rockets + " rockets" + 
                    "\nNext: " + (rockets + 1) + " rockets" + 
                    "\nUpgrade cost: " + coinsRequired + " coins";
            }
            
            if (upgradeLevel == maxlevel) {
                ismaxlevel = true;
            }

            if (ismaxlevel) {
                rocketLauncherEffects.text = "Current: " + rockets + " rockets" + 
                        "\nMAX LEVEL";
            }
        }
    }
}
