using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimewarpButton : MonoBehaviour
{
    [SerializeField] private TMP_Text timewarpEffects;
    public static TimewarpButton timewarpInstance;

    private static int upgradeLevel = 1;
    private int maxlevel = 5;
    private static bool ismaxlevel = false;

    private static int coinsRequired = 25;
    public static float timewarpDuration = 5f;

    public void Awake() {
        if (timewarpInstance == null) {
            timewarpInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (ismaxlevel) {
            timewarpEffects.text = "Current: " + timewarpDuration + " seconds" + 
                    "\nMAX LEVEL";
        } else {
            timewarpEffects.text = "Current: " + timewarpDuration + " seconds" + 
                "\nNext: " + (timewarpDuration + 1.25f) + " seconds" + 
                "\nUpgrade cost: " + coinsRequired + " coins";
        }
    }

    public void UpgradeTimewarp() {
        if (UpgradeMenu.coins >= coinsRequired) {
            if (!ismaxlevel) {
                upgradeLevel += 1;
                UpgradeMenu.coins -= coinsRequired;
                // Debug.Log("Coins: " + UpgradeMenu.coins);

                timewarpDuration += 1.25f;
                coinsRequired += (coinsRequired / 6) + 8;
                timewarpEffects.text = "Current: " + timewarpDuration + " seconds" + 
                    "\nNext: " + (timewarpDuration + 1.25f) + " seconds" + 
                    "\nUpgrade cost: " + coinsRequired + " coins";
            }
            
            if (upgradeLevel == maxlevel) {
                ismaxlevel = true;
            }

            if (ismaxlevel) {
                timewarpEffects.text = "Current: " + timewarpDuration + " seconds" + 
                        "\nMAX LEVEL";
            }
        }
    }
}
