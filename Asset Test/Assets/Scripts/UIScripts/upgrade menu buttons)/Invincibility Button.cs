using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InvincibilityButton : MonoBehaviour
{
    [SerializeField] private TMP_Text invincibilityEffects;
    public static InvincibilityButton invincibilityInstance;

    private static int upgradeLevel = 1;
    private int maxlevel = 5;
    private static bool ismaxlevel = false;

    private static int coinsRequired = 50;
    public static float InvincibilityDuration = 6f;

    public void Awake() {
        if (invincibilityInstance == null) {
            invincibilityInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (!ismaxlevel) {
            invincibilityEffects.text = "Current: " + InvincibilityDuration + " seconds" + 
                "\nNext: " + (InvincibilityDuration + 1f) + " seconds" +
                "\nUpgrade cost: " + coinsRequired + " coins";
        } else {
            invincibilityEffects.text = "Current: " + InvincibilityDuration + " seconds" + 
                        "\nMAX LEVEL";
        }
    }

    public void UpgradeInvincibility() {
        if (UpgradeMenu.coins >= coinsRequired) {
            if (!ismaxlevel) {
                upgradeLevel += 1;
                UpgradeMenu.coins -= coinsRequired;
                // Debug.Log("Coins: " + UpgradeMenu.coins);

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
