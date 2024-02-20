using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesCounterScript : MonoBehaviour
{
    [SerializeField] private TMP_Text livesCounter;
    private int livesCount = 3;

    private void OnEnable()
    {
        EventScriptManager.onPlayerCollectLifeEvent += AddLife;
        EventScriptManager.onPlayerLoseLifeEvent += SubtractLife;
        // Event.onPlayerCollectLifeEvent += AddLife;
        // Event.onPlayerLoseLifeEvent += SubtractLife;
    }

    private void OnDisable()
    {
        EventScriptManager.onPlayerCollectLifeEvent -= AddLife;
        EventScriptManager.onPlayerLoseLifeEvent -= SubtractLife;
        // Event.onPlayerCollectLifeEvent -= AddLife;
        // Event.onPlayerLoseLifeEvent -= SubtractLife;
    }

    private void Start()
    {
        livesCounter.SetText(livesCount.ToString());
    }

    private void AddLife(EventScriptManager events) // argument should be EventScript event
    {
        Debug.Log("Life collection event heard");
        livesCount++;
        livesCounter.SetText(livesCount.ToString());
    }

    private void SubtractLife(EventScriptManager events)
    {
        Debug.Log("Life loss event heard");
        livesCount--;
        livesCounter.SetText(livesCount.ToString());
    }
}
