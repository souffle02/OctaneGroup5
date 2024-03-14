using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CoinMultiplierButton : MonoBehaviour
{
    [SerializeField] private TMP_Text coinMultiplierEffects;
    private int coinCount;
    private int upgradeLevel;
    private float coinMultiplierDuration;
    
    // Start is called before the first frame update
    void Start()
    {
        upgradeLevel = 1;
        coinMultiplierDuration = 10f;  // initial duration is 10 seconds
        coinMultiplierEffects.text = "Current: " + coinMultiplierDuration + " seconds" + 
            "\nNext: " + (coinMultiplierDuration + 2.5f) + " seconds";
    }

    public void UpgradeCoinMultipier() {
        upgradeLevel += 1;
        if (upgradeLevel < 5) {
            coinMultiplierDuration += 2.5f;
            coinMultiplierEffects.text = "Current: " + coinMultiplierDuration + " seconds" + 
                "\nNext: " + (coinMultiplierDuration + 2.5f) + " seconds";
        } else {
            coinMultiplierEffects.text = "Current: " + (coinMultiplierDuration + 2.5f) + " seconds" + 
                "\nMAX LEVEL";
        }
    }
}
