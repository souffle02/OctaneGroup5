using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LogCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text logCounter;
    public static LogCounter LogsInstance;
    private List<int> logCounts = new List<int> { 0, 0, 0, 0 };
    public int CURR_LEVEL = 0;
    private List<int> logCountPerLevel = new List<int> { 2, 2, 2, 2 };

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
        Debug.Log(logCounts[0]);
        logCounter.SetText(logCounts[CURR_LEVEL].ToString() + "/" + logCountPerLevel[CURR_LEVEL].ToString());
    }

    // Public property to access the data
    public List<int> LogCounts
    {
        get { return logCounts; }
        set { logCounts = value; }
    }


    private void AddLog(Lore events) // argument should be EventScript event
    {
        Debug.Log("Log collection event heard");
        logCounts[CURR_LEVEL]++;
        logCounter.SetText(logCounts[CURR_LEVEL].ToString() + "/" + logCountPerLevel[CURR_LEVEL].ToString());
    }
}
