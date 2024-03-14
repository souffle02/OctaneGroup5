using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UpgradeMenu : MonoBehaviour
{
    public int coins;
    [SerializeField] public TMP_Text coinText;

    public void Start() {
        coins = 1000;
        coinText.text = coins + "";
    }

    public void LevelSelector() {
        SceneManager.LoadScene("Level Selector");
    }
}
