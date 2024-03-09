using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InvincibilityButton : MonoBehaviour
{
    [SerializeField] private TMP_Text invincibilityEffects;
    private float InvincibilityDuration;
    
    // Start is called before the first frame update
    void Start()
    {
        InvincibilityDuration = 6f;  // initial invincibility duration is 6 seconds
        invincibilityEffects.text = "Current: " + InvincibilityDuration + " seconds" + 
            "\nNext: " + (InvincibilityDuration + 1f) + " seconds";
    }

    public void UpgradeInvincibility() {
        InvincibilityDuration += 1f;
        invincibilityEffects.text = "Current: " + InvincibilityDuration + " seconds" + 
            "\nNext: " + (InvincibilityDuration + 1f) + " seconds";
    }
}
