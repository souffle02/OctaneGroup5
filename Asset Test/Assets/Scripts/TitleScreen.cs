using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{

    public void OpenScene()
    {
        SceneManager.LoadScene("Level Selector");
    }
}
