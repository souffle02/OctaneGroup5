using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private TMP_Text coinCounter;
    [SerializeField] private TMP_Text logCounter;
    [SerializeField] private TMP_Text livesCounter;
    void Start()
    {
        coinCounter.SetText(GameManager.Instance.coinCounter.text);
        logCounter.SetText(GameManager.Instance.logCounter.text);
        livesCounter.SetText(GameManager.Instance.livesCounter.text);
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene("Level Selector");
    }
}
