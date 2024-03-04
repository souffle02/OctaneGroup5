using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesCounterScript : MonoBehaviour
{
    [SerializeField] private TMP_Text livesCounter;
    public int livesCount = 3;
    // private bool invincible;  // may not need the invincibility section since a script was made for it already
    public static LivesCounterScript LivesInstance;

    private void OnEnable()
    {
        RepairKit.onCollectRepairKit += AddLife;
        PlayerController.onPlayerLoseLifeEvent += SubtractLife;
        EventScriptManager.onCollectLifeRestore += LivesRestored;        
        // Event.onPlayerCollectLifeEvent += AddLife;
        // Event.onPlayerLoseLifeEvent += SubtractLife;
    }

    private void OnDisable()
    {
        RepairKit.onCollectRepairKit -= AddLife;
        PlayerController.onPlayerLoseLifeEvent -= SubtractLife;
        EventScriptManager.onCollectLifeRestore -= LivesRestored;
        // Event.onPlayerCollectLifeEvent -= AddLife;
        // Event.onPlayerLoseLifeEvent -= SubtractLife;
    }

    private void Start()
    {
        livesCounter.SetText(livesCount.ToString());
        // invincible = false;
    }
    private void Awake()
    {
        if (LivesInstance == null)
        {
            LivesInstance = this;
        }
    }
    /*
    public void UpdateLives()
    {
        livesCount = PlayerController.lives;
        livesCounter.SetText(livesCount.ToString());
    }
    */

    private void AddLife(RepairKit events) // argument should be EventScript event
    {
        Debug.Log("Life collection event heard");
        livesCount++;
        livesCounter.SetText(livesCount.ToString());
    }

    private void SubtractLife(PlayerController events)
    {
        Debug.Log("Life loss event heard");
        livesCount--;
        livesCounter.SetText(livesCount.ToString());
        if (livesCount <= 0) {
            Debug.Log("Game Over");
            GameManager.Instance.GameOver();
        }
    }
    private void LivesRestored(EventScriptManager powerup) {
        Debug.Log("Lives fully restored");
        livesCount = 3;
        livesCounter.SetText(livesCount.ToString());
    }
}
