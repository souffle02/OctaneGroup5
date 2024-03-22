using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class RestartLevel : MonoBehaviour
{
    private int current_level;
    [SerializeField] Button resetButton;
    void Start()
    {
        if (PlayerController.PlayerInstance == null)
        {
            current_level = 1;
        }
        else
            current_level = PlayerController.PlayerInstance.currLevel;
        resetButton.onClick.AddListener(Reset);
    }

    // Update is called once per frame
    void Reset()
    {
        SceneManager.LoadScene("Level " + current_level);
        CoinCounterScript.coinCount = 0;
        Time.timeScale = 1;
    }
}
