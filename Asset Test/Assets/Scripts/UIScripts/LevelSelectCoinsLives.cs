using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class LevelSelectCoinsLives : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private TMP_Text livesText;

    private int coinsCount;
    private int livesCount;

    private void Start()
    {
        coinsCount = CoinCounterScript.CoinsInstance.coinCount;
        livesCount = LivesCounterScript.LivesInstance.livesCount;
        coinText.SetText(coinsCount.ToString());
        livesText.SetText(livesCount.ToString());
    }
}
