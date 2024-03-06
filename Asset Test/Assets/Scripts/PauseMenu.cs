using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject HUD;
    void Start()
    {
        EventScriptManager.pauseMenuEvent += pauseMenuToggle;
    }

    void pauseMenuToggle(EventScriptManager pause)
    {
        if(Time.timeScale == 0)
        {
            pauseMenu.SetActive(false);
            HUD.SetActive(true);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            pauseMenu.SetActive(true);
            HUD.SetActive(false);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

}
