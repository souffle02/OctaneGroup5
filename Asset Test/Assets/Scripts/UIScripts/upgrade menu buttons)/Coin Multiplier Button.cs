using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CoinMultiplierButton : MonoBehaviour
{
    [SerializeField] private TMP_Text coinMultiplierEffects;
    private int coinCount;
    private float coinMultiplierDuration;
    
    // Start is called before the first frame update
    void Start()
    {
        coinMultiplierDuration = 10f;  // initial duration is 10 seconds
        coinMultiplierEffects.text = "Current: " + coinMultiplierDuration + " seconds" + 
            "\nNext: " + (coinMultiplierDuration + 2f) + " seconds";
    }

    public void UpgradeCoinMultipier() {
        coinMultiplierDuration += 2f;
        coinMultiplierEffects.text = "Current: " + coinMultiplierDuration + " seconds" + 
            "\nNext: " + (coinMultiplierDuration + 2f) + " seconds";
    }
}
