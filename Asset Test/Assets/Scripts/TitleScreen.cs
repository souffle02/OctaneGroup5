using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] GameObject levelSelectCanvas;

    public void OpenScene()
    {
        levelSelectCanvas.SetActive(true);
    }
}
