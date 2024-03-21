using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private TMP_Text loreText;

    public static int coinsCount;
    public static int livesCount;
    private List<int> loreCount;
    public int currLevel;

    public static event Action<GameOverScript> gameOverEvent;
    // private int CURR_LEVEL;

    private void Start()
    {
        // Need to add logic to get level
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        coinsCount = CoinCounterScript.coinCount;
        // livesCount = LivesCounterScript.LivesInstance.livesCount;
        livesCount = LivesCounterScript.livesCount;
        loreCount = LogCounter.LogsInstance.LogCounts;
        currLevel = PlayerController.PlayerInstance.currLevel;
        // CURR_LEVEL = LogCounter.LogsInstance.CURR_LEVEL;

        coinsText.SetText(coinsCount.ToString());
        livesText.SetText(livesCount.ToString());
        loreText.SetText(loreCount[currLevel-1].ToString() + " / 2");
    }

    public void onButtonClick()
    {
        gameOverEvent?.Invoke(this);
        Debug.Log("Loading scene");
        CoinCounterScript.coinCount = 0;
        LivesCounterScript.livesCount = 3;
        SceneManager.LoadScene("Level 1");
    }
}
