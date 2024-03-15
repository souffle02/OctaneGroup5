using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimewarpButton : MonoBehaviour
{
    [SerializeField] private TMP_Text timewarpEffects;
    private int upgradeLevel;
    private int maxlevel = 5;
    private bool ismaxlevel;

    private int coinsRequired;
    private float timewarpDuration;
    
    // Start is called before the first frame update
    void Start()
    {
        upgradeLevel = 1;
        ismaxlevel = false;
        coinsRequired = 60;

        timewarpDuration = 5f;  // initial timewarp duration is 5 seconds
        timewarpEffects.text = "Current: " + timewarpDuration + " seconds" + 
            "\nNext: " + (timewarpDuration + 1.25f) + " seconds" + 
            "\nUpgrade cost: " + coinsRequired + " coins";
    }

    public void UpgradeTimewarp() {
        if (UpgradeMenu.coins >= coinsRequired) {
            if (!ismaxlevel) {
                upgradeLevel += 1;
                UpgradeMenu.coins -= coinsRequired;
                Debug.Log("Coins: " + UpgradeMenu.coins);

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
