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
        SampleCollectibles collectibleCount = FindObjectOfType<SampleCollectibles>(); // replace this with the script that has the global coin count variable
        if (collectibleCount != null)
        {
            coinsCount = collectibleCount.coinsCount;
            livesCount = collectibleCount.livesCount;
        }
        else
        {
            coinsCount = -999;
            livesCount = -999;
        }
        coinText.SetText(coinsCount.ToString());
        livesText.SetText(livesCount.ToString());
    }
}
