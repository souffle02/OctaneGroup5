using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private TMP_Text loreText;

    private int coinsCount;
    private int livesCount;
    private List<int> loreCount;
    public int currLevel;
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
        Debug.Log("Loading scene");
        SceneManager.LoadScene("Level 1");
    }
}
