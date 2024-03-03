using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level3EndScript : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private TMP_Text loreText;

    private int coinsCount;
    private int livesCount;
    private int loreCount;

    private void Start()
    {
        SampleCollectibles collectibleCount = FindObjectOfType<SampleCollectibles>(); // replace this with the script that has the global coin count variable
        if (collectibleCount != null)
        {
            coinsCount = collectibleCount.coinsCount;
            livesCount = collectibleCount.livesCount;
            loreCount = collectibleCount.level3_loreCount;
        }
        else
        {
            coinsCount = -999;
            livesCount = -999;
            loreCount = -999;
        }
        coinsText.SetText(coinsCount.ToString());
        livesText.SetText(livesCount.ToString());
        loreText.SetText(loreCount.ToString() + " / 2");
    }
}
