using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public int level;
    void Start()
    {
        
    }


    public void OpenScene()
    {
        Debug.Log("Loading level " + level.ToString());
        SceneManager.LoadScene("Level " + level.ToString());
    }
}
