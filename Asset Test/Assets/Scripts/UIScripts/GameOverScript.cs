using UnityEngine;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private TMP_Text loreText;

    private int coinsCount;
    private int livesCount;
    private int loreCount;

    private void Start()
    {
        // Need to add logic to get level
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        coinsCount = CoinCounterScript.CoinsInstance.coinCount;
        livesCount = LivesCounterScript.LivesInstance.livesCount;
        loreCount = LogCounter.LogsInstance.logCount;

        coinsText.SetText(coinsCount.ToString());
        livesText.SetText(livesCount.ToString());
        loreText.SetText(loreCount.ToString() + " / 2");
    }
}
