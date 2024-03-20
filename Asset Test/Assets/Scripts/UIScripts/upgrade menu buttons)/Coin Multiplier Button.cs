using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CoinMultiplierButton : MonoBehaviour
{
    [SerializeField] private TMP_Text coinMultiplierEffects;
    public static CoinMultiplierButton multiplierInstance;

    private static int upgradeLevel = 1;
    private int maxlevel = 5;
    private static bool ismaxlevel = false;

    private static int coinsRequired = 15;
    public static float coinMultiplierDuration = 10f;

    public void Awake() {
        if (multiplierInstance == null) {
            multiplierInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (!ismaxlevel) {
            coinMultiplierEffects.text = "Current: " + coinMultiplierDuration + " seconds" + 
                "\nNext: " + (coinMultiplierDuration + 2.5f) + " seconds" +
                "\nUpgrade cost: " + coinsRequired + " coins";
        } else {
            coinMultiplierEffects.text = "Current: " + coinMultiplierDuration + " seconds" + 
                        "\nMAX LEVEL";
        }
    }

    public void UpgradeCoinMultipier() {
        if (UpgradeMenu.coins >= coinsRequired) {
            if (!ismaxlevel) {
                upgradeLevel += 1;
                UpgradeMenu.coins -= coinsRequired;
                // Debug.Log("Coins: " + UpgradeMenu.coins);

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
