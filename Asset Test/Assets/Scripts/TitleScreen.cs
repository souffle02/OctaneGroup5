using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] GameObject levelSelectCanvas;

    public void OpenScene()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Quit() {
        Application.Quit();
    }
}
