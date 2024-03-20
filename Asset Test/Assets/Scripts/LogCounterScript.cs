using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LogCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text logCounter;
    public static LogCounter LogsInstance;
    private List<int> logCounts = new List<int> { 0, 0, 0, 0 }; // 1 - indexed
    // public int CURR_LEVEL = 0;
    public int currLevel;
    private List<int> logCountPerLevel = new List<int> { 0, 2, 2, 2 };

    private void OnEnable()
    {
        Lore.onPlayerCollectLogEvent += AddLog;
        PlayerController.giveAllLoreEvent += GiveAllLogs;
        // Event.onPlayerCollectLogEvent += AddLog;
    }

    private void OnDisable()
    {
        Lore.onPlayerCollectLogEvent -= AddLog;
        PlayerController.giveAllLoreEvent -= GiveAllLogs;
        // Event.onPlayerCollectLogEvent -= AddLog;
    }

    private void Awake()
    {
        LogsInstance = this;
    }

    private void Start()
    {
        currLevel = PlayerController.PlayerInstance.currLevel;
        Debug.Log("CURRLEVEL:" + currLevel);
        logCounter.SetText(logCounts[currLevel].ToString() + "/" + logCountPerLevel[currLevel].ToString());
    }

    // Public property to access the data
    public List<int> LogCounts
    {
        get { return logCounts; }
        set { logCounts = value; }
    }


    private void AddLog(Lore events) // argument should be EventScript event
    {
        LogCounter thisScript = new LogCounter();
        Debug.Log("Log collection event heard");
        if (logCounts[currLevel] >= 2)
        {
            logCounts[currLevel] = 2;
        }
        else
        {
            logCounts[currLevel]++;
        }
        thisScript.LogCounts = logCounts;
        logCounter.SetText(logCounts[currLevel].ToString() + "/" + logCountPerLevel[currLevel].ToString());
    }

    private void GiveAllLogs(PlayerController events)
    {
        LogCounter thisScript = new LogCounter();
        logCounts[0] = 2;
        logCounts[1] = 2;
        logCounts[2] = 2;
        logCounts[3] = 2;
        thisScript.LogCounts = logCounts;
        logCounter.SetText(logCounts[currLevel].ToString() + "/" + logCountPerLevel[currLevel].ToString());
    }
}
