using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Level1EndScript : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private TMP_Text loreText;

    private int coinsCount;
    private int livesCount;
    private int loreCount;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //CoinCounterScript coinCollectibleCount = FindObjectOfType<CoinCounterScript>(); // coin
        coinsCount = CoinCounterScript.CoinsInstance.coinCount;
        livesCount = LivesCounterScript.LivesInstance.livesCount;
        loreCount = LogCounter.LogsInstance.logCount;
        LivesCounterScript lifeCollectibleCount = FindObjectOfType<LivesCounterScript>(); // life
        LogCounter loreCollectibleCount = FindObjectOfType<LogCounter>(); // lore
        coinsText.SetText(coinsCount.ToString());
        livesText.SetText(livesCount.ToString());
        loreText.SetText(loreCount.ToString() + " / 2");
    }

    public void onButtonClick() {
        Debug.Log("Loading scene: Level 2");
        SceneManager.LoadScene("Level 2");
    }
}
