using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerupCollectionManager : MonoBehaviour
{
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
