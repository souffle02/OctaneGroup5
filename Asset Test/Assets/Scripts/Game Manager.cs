using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] public TMP_Text coinCounter;
    [SerializeField] public TMP_Text logCounter;
    [SerializeField] public TMP_Text livesCounter;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    public void LevelEnd()
    {
        SceneManager.LoadScene("Level End");
    }
}
