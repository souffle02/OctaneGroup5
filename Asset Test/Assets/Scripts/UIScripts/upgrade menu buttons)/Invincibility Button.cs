using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InvincibilityButton : MonoBehaviour
{
    [SerializeField] private TMP_Text invincibilityEffects;
    private int upgradeLevel;
    private int maxlevel = 5;
    private bool ismaxlevel;

    private int coinsRequired;
    private float InvincibilityDuration;
    
    // Start is called before the first frame update
    void Start()
    {
        upgradeLevel = 1;
        ismaxlevel = false;
        coinsRequired = 50;

        InvincibilityDuration = 6f;  // initial invincibility duration is 6 seconds
        invincibilityEffects.text = "Current: " + InvincibilityDuration + " seconds" + 
            "\nNext: " + (InvincibilityDuration + 1f) + " seconds" + 
            "\nUpgrade cost: " + coinsRequired + " coins";
    }

    public void UpgradeInvincibility() {
        if (UpgradeMenu.coins >= coinsRequired) {
            if (!ismaxlevel) {
                upgradeLevel += 1;
                UpgradeMenu.coins -= coinsRequired;
                Debug.Log("Coins: " + UpgradeMenu.coins);

                InvincibilityDuration += 1f;
                coinsRequired += (coinsRequired / 5) + 10;
                invincibilityEffects.text = "Current: " + InvincibilityDuration + " seconds" + 
                    "\nNext: " + (InvincibilityDuration + 1f) + " seconds" + 
                    "\nUpgrade cost: " + coinsRequired + " coins";
            }
            
            if (upgradeLevel == maxlevel) {
                ismaxlevel = true;
            }

            if (ismaxlevel) {
                invincibilityEffects.text = "Current: " + InvincibilityDuration + " seconds" + 
                        "\nMAX LEVEL";
            }
        }
    }
}
