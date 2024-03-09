using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimewarpButton : MonoBehaviour
{
    [SerializeField] private TMP_Text timewarpEffects;
    private float timewarpDuration;
    
    // Start is called before the first frame update
    void Start()
    {
        timewarpDuration = 5f;  // initial timewarp duration is 5 seconds
        timewarpEffects.text = "Current: " + timewarpDuration + " seconds" + 
            "\nNext: " + (timewarpDuration + 1.25f) + " seconds";
    }

    public void UpgradeTimewarp() {
        timewarpDuration += 1.25f;
        timewarpEffects.text = "Current: " + timewarpDuration + " seconds" + 
            "\nNext: " + (timewarpDuration + 1.25f) + " seconds";
    }
}
