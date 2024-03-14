using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RocketLauncherUpgrade : MonoBehaviour
{
    [SerializeField] private TMP_Text rocketLauncherEffects;
    private int upgradeLevel;
    private int rockets;
    
    // Start is called before the first frame update
    void Start()
    {
        rockets = 1;  // initial number of rockets stored is 1, can be upgraded to store up to 3
        rocketLauncherEffects.text = "Current: " + rockets + " rockets" + 
            "\nNext: " + (rockets + 1) + " rockets";
    }

    public void UpgradeRocketLauncher() {
        upgradeLevel += 1;
        if (upgradeLevel < 3) {
            rockets += 1;
            rocketLauncherEffects.text = "Current: " + rockets + " rockets" + 
                "\nNext: " + (rockets + 1) + " rockets";
        } else {
            rocketLauncherEffects.text = "Current: " + (rockets + 1) + " rockets" + 
            "\nMAX LEVEL";
        }
    }
}
