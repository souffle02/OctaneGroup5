using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void Level1End()
    {
        SceneManager.LoadScene("Level1End");
    }
    public void Level2End()
    {
        SceneManager.LoadScene("Level2End");
    }
    public void Level3End()
    {
        SceneManager.LoadScene("Level3End");
    }
}
