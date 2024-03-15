using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCollectibles : MonoBehaviour
{
    public int coinsCount;
    public int livesCount;
    public int level1_loreCount;
    public int level2_loreCount;
    public int level3_loreCount;

    private void Start()
    {
        coinsCount = 12;
        livesCount = 2;
        level1_loreCount = 1;
        level2_loreCount = 0;
        level3_loreCount = 2;
    }
}
