using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasSwitcherScript : MonoBehaviour
{
    public void ChangeToLevelSelect() {
        SceneManager.LoadScene("Level Selector");
    }
}
