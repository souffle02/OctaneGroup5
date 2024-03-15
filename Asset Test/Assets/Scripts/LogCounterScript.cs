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
        // Event.onPlayerCollectLogEvent += AddLog;
    }

    private void OnDisable()
    {
        Lore.onPlayerCollectLogEvent -= AddLog;
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
        logCounts[currLevel]++;
        thisScript.LogCounts = logCounts;
        logCounter.SetText(logCounts[currLevel].ToString() + "/" + logCountPerLevel[currLevel].ToString());
    }
}
