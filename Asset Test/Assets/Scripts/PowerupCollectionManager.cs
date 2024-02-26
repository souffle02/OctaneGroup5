using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerupCollectionManager : MonoBehaviour
{
    /*
    power-up effects:

    these will use booleans:
    coin multiplier - boolean on coin counter set to true; when true, all coins picked up are doubled
    invincibility - boolean on life counter set to true; when true, running into obstacles will not subtract lives

    effects that will be used instantly:
    repair kit - fully repairs all damage on player car
    life restore - restores all lives instantly
    timewarp - all action moves at 60-70% normal speed for 10 seconds
    rocket launcher - a rocket is fired back at the chasing police cars, which will be "stunned" for 8 seconds.
    */

    public static event Action<PowerupCollectionManager> onCollectCoinMultiplier;
    public static event Action<PowerupCollectionManager> onCollectInvincibility;
    public static event Action<PowerupCollectionManager> onCollectRepairKit;
    public static event Action<PowerupCollectionManager> onCollectLifeRestore;
    public static event Action<PowerupCollectionManager> onCollectTimewarp;
    public static event Action<PowerupCollectionManager> onCollectRocketLauncher;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            onCollectCoinMultiplier?.Invoke(this);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            onCollectInvincibility?.Invoke(this);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            onCollectRepairKit?.Invoke(this);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            onCollectLifeRestore?.Invoke(this);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            onCollectTimewarp?.Invoke(this);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            onCollectRocketLauncher?.Invoke(this);
        }
    }
}
