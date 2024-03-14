using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InvincibilityButton : MonoBehaviour
{
    [SerializeField] private TMP_Text invincibilityEffects;
    private int upgradeLevel;
    private float InvincibilityDuration;
    
    // Start is called before the first frame update
    void Start()
    {
        upgradeLevel = 1;
        InvincibilityDuration = 6f;  // initial invincibility duration is 6 seconds
        invincibilityEffects.text = "Current: " + InvincibilityDuration + " seconds" + 
            "\nNext: " + (InvincibilityDuration + 1f) + " seconds";
    }

    public void UpgradeInvincibility() {
        upgradeLevel += 1;
        if (upgradeLevel < 5) {
            InvincibilityDuration += 1f;
            invincibilityEffects.text = "Current: " + InvincibilityDuration + " seconds" + 
                "\nNext: " + (InvincibilityDuration + 1f) + " seconds";
        } else {
            invincibilityEffects.text = "Current: " + (InvincibilityDuration + 1f) + " seconds" + 
                "\nMAX LEVEL";
        }
    }
}
