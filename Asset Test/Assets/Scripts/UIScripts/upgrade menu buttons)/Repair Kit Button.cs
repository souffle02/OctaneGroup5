using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RepairKitButton : MonoBehaviour
{
    [SerializeField] private TMP_Text repairKitEffects;
    private int c;
    private int upgradeLevel;
    private int coinsRequired;
    private int livesRestored;
    public GameObject menuCoins;
    
    // Start is called before the first frame update
    void Start()
    {
        menuCoins = GameObject.Find("menuItems");
        UpgradeMenu up = menuCoins.GetComponent<UpgradeMenu>();
        c = up.coins;

        upgradeLevel = 1;
        coinsRequired = 15;
        livesRestored = 1;  // initial lives restored is 1
        repairKitEffects.text = "Current: " + livesRestored + " life" + 
            "\nNext: " + (livesRestored + 1) + " lives" + 
            "\nCoins for next level: " + coinsRequired;
    }

    public void UpgradeRepairKit() {
        if (c >= coinsRequired) {
            upgradeLevel += 1;
            SubtractCoins(coinsRequired);
            if (upgradeLevel < 2) {
                livesRestored += 1;
                repairKitEffects.text = "Current: " + livesRestored + " lives" + 
                    "\nNext: " + (livesRestored + 1) + " lives" + 
                    "\nCoins for next level: " + coinsRequired;
            } else {
                repairKitEffects.text = "Current: " + (livesRestored + 1) + " lives" + 
                    "\nMAX LEVEL";
            }
        }
    }

    private void SubtractCoins(int cost) {
        UpgradeMenu up = menuCoins.GetComponent<UpgradeMenu>();
        up.coinText.text = (c - cost) + "";
    }
}
