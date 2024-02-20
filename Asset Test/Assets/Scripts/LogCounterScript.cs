using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LogCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text logCounter;
    private int logCount = 0;
    private int CURR_LEVEL = 0;
    private List<int> logCountPerLevel = new List<int> { 2, 2, 2, 2 };

    private void OnEnable()
    {
        EventScriptManager.onPlayerCollectLogEvent += AddLog;
        // Event.onPlayerCollectLogEvent += AddLog;
    }

    private void OnDisable()
    {
        EventScriptManager.onPlayerCollectLogEvent -= AddLog;
        // Event.onPlayerCollectLogEvent -= AddLog;
    }

    private void Start()
    {
        logCounter.SetText(logCount.ToString() + "/" + logCountPerLevel[CURR_LEVEL].ToString());
    }

    private void AddLog(EventScriptManager events) // argument should be EventScript event
    {
        Debug.Log("Log collection event heard");
        logCount++;
        logCounter.SetText(logCount.ToString() + "/" + logCountPerLevel[CURR_LEVEL].ToString());
    }
}
