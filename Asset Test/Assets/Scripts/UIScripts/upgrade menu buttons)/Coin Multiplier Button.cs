using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CoinMultiplierButton : MonoBehaviour
{
    [SerializeField] private TMP_Text coinMultiplierEffects;
    private int upgradeLevel;
    private int maxlevel = 5;
    private bool ismaxlevel;

    private int coinsRequired;
    private float coinMultiplierDuration;

    public GameObject _gameObject;
    
    // Start is called before the first frame update
    void Start()
    {
        upgradeLevel = 1;
        ismaxlevel = false;
        coinsRequired = 20;
        coinMultiplierDuration = 10f;  // initial duration is 10 seconds
        coinMultiplierEffects.text = "Current: " + coinMultiplierDuration + " seconds" + 
            "\nNext: " + (coinMultiplierDuration + 2.5f) + " seconds" +
            "\nUpgrade cost: " + coinsRequired + " coins";
    }

    public void UpgradeCoinMultipier() {
        if (UpgradeMenu.coins >= coinsRequired) {
            if (!ismaxlevel) {
                upgradeLevel += 1;
                UpgradeMenu.coins -= coinsRequired;
                Debug.Log("Coins: " + UpgradeMenu.coins);
                // UpgradeMenu.coinText.text = UpgradeMenu.coins + "";

                coinMultiplierDuration += 2.5f;
                coinsRequired += (coinsRequired / 2) + 5;
                coinMultiplierEffects.text = "Current: " + coinMultiplierDuration + " seconds" + 
                    "\nNext: " + (coinMultiplierDuration + 2.5f) + " seconds" + 
                    "\nUpgrade cost: " + coinsRequired + " coins";
            }
            
            if (upgradeLevel == maxlevel) {
                ismaxlevel = true;
            }

            if (ismaxlevel) {
                coinMultiplierEffects.text = "Current: " + coinMultiplierDuration + " seconds" + 
                        "\nMAX LEVEL";
            }
        }
    }
}
