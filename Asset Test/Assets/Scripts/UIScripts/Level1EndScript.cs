using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;

public class Level1EndScript : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private TMP_Text loreText;

    private int coinsCount;
    private int livesCount;
    private List<int> loreCount;
    private int CURR_LEVEL;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //CoinCounterScript coinCollectibleCount = FindObjectOfType<CoinCounterScript>(); // coin
        coinsCount = CoinCounterScript.CoinsInstance.coinCount;
        livesCount = LivesCounterScript.LivesInstance.livesCount;
        loreCount = LogCounter.LogsInstance.LogCounts;
        CURR_LEVEL = LogCounter.LogsInstance.CURR_LEVEL;
        Debug.Log("CURRLEVEL: " + CURR_LEVEL);
        Debug.Log("LOGCOUNT" + String.Join("; ", loreCount));
        LivesCounterScript lifeCollectibleCount = FindObjectOfType<LivesCounterScript>(); // life
        LogCounter loreCollectibleCount = FindObjectOfType<LogCounter>(); // lore
        coinsText.SetText(coinsCount.ToString());
        livesText.SetText(livesCount.ToString());
        loreText.SetText(loreCount[CURR_LEVEL].ToString() + " / 2");
    }

    /* public void onButtonClick() {
        Debug.Log("Loading scene: Level 2");
        SceneManager.LoadScene("Level 2");
    } */
}
