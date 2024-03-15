using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventScriptManager : MonoBehaviour
{
    public static event Action<EventScriptManager> onPlayerCollectCoinEvent;
    public static event Action<EventScriptManager> onPlayerCollectLogEvent;
    public static event Action<EventScriptManager> onPlayerCollectLifeEvent;
    public static event Action<EventScriptManager> onPlayerLoseLifeEvent;

    public static event Action<EventScriptManager> onCollectCoinMultiplier;
    public static event Action<EventScriptManager> onCollectInvincibility;
    public static event Action<EventScriptManager> onCollectRepairKit;
    public static event Action<EventScriptManager> onCollectLifeRestore;
    public static event Action<EventScriptManager> onCollectTimewarp;
    public static event Action<EventScriptManager> onCollectRocketLauncher;

    public static event Action<EventScriptManager> pauseMenuEvent;

    // Update is called once per frame
    void Update()
    {
        // common events
        if (Input.GetKeyDown(KeyCode.C))
        {
            onPlayerCollectCoinEvent?.Invoke(this);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            onPlayerCollectLogEvent?.Invoke(this);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            onPlayerCollectLifeEvent?.Invoke(this);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            onPlayerLoseLifeEvent?.Invoke(this);
        }

        // powerups
        if (Input.GetKeyDown(KeyCode.M))
        {
            onCollectCoinMultiplier?.Invoke(this);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            onCollectLifeRestore?.Invoke(this);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Invincibility triggered");
            onCollectInvincibility?.Invoke(this);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            onCollectRepairKit?.Invoke(this);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            onCollectTimewarp?.Invoke(this);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            onCollectRocketLauncher?.Invoke(this);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuEvent?.Invoke(this);
        }
    }
}
