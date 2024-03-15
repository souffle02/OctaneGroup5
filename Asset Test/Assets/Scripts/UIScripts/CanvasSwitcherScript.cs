using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwitcherScript : MonoBehaviour
{
    [SerializeField] GameObject nextUI;

    private void Start()
    {
        nextUI.SetActive(false);
    }

    public void ChangeToLevelSelect(GameObject levelSelectCanvas)
    {
        nextUI.SetActive(true);    }
}
