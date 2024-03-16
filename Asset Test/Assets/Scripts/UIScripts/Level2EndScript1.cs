using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;

public class Level2EndScript : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private TMP_Text loreText;

    private int coinsCount;
    private int livesCount;
    private List<int> loreCount;
    // private int CURR_LEVEL;
    public int currLevel;

    public static Level2EndScript level2endHandler;

    public void Awake()
    {
        level2endHandler = this;
    }


    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        // coinsCount = CoinCounterScript.CoinsInstance.coinCount;
        coinsCount = CoinCounterScript.coinCount;
        // livesCount = LivesCounterScript.LivesInstance.livesCount;
        livesCount = LivesCounterScript.livesCount;
        loreCount = LogCounter.LogsInstance.LogCounts;
        // CURR_LEVEL = LogCounter.LogsInstance.CURR_LEVEL;
        currLevel = PlayerController.PlayerInstance.currLevel;
        Debug.Log("CURRLEVEL: " + currLevel);
        Debug.Log("LOGCOUNT" + String.Join("; ", loreCount));
        LivesCounterScript lifeCollectibleCount = FindObjectOfType<LivesCounterScript>(); // life
        LogCounter loreCollectibleCount = FindObjectOfType<LogCounter>(); // lore
        coinsText.SetText(coinsCount.ToString());
        livesText.SetText(livesCount.ToString());
        loreText.SetText(loreCount[currLevel].ToString() + " / 2");
        currLevel++;
        Debug.Log("NEW CURRLEVEL: " + currLevel);
    }

    /* public void onButtonClick() {
        Debug.Log("Loading scene: Level 2");
        SceneManager.LoadScene("Level 2");
    } */
}
