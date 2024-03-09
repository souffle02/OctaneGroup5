using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeMenu : MonoBehaviour
{
    public void LevelSelector() {
        SceneManager.LoadScene("Level Selector");
    }
}
