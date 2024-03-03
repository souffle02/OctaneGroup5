using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwitcherScript : MonoBehaviour
{
    [SerializeField] GameObject levelSelectCanvas;

    private void Start()
    {
        levelSelectCanvas.SetActive(false);
    }

    public void ChangeToLevelSelect(GameObject levelSelectCanvas)
    {
        levelSelectCanvas.SetActive(true);
    }
}
