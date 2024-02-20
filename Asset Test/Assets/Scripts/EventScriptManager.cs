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

    // Update is called once per frame
    void Update()
    {
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
    }
}
