using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimewarpButton : MonoBehaviour
{
    [SerializeField] private TMP_Text timewarpEffects;
    private int upgradeLevel;
    private float timewarpDuration;
    
    // Start is called before the first frame update
    void Start()
    {
        upgradeLevel = 1;
        timewarpDuration = 5f;  // initial timewarp duration is 5 seconds
        timewarpEffects.text = "Current: " + timewarpDuration + " seconds" + 
            "\nNext: " + (timewarpDuration + 1.25f) + " seconds";
    }

    public void UpgradeTimewarp() {
        upgradeLevel += 1;
        if (upgradeLevel < 5) {
            timewarpDuration += 1.25f;
            timewarpEffects.text = "Current: " + timewarpDuration + " seconds" + 
                "\nNext: " + (timewarpDuration + 1.25f) + " seconds";
        } else {
            timewarpEffects.text = "Current: " + (timewarpDuration + 1.25f) + " seconds" + 
                "\nMAX LEVEL";
        }
    }
}
