using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class LevelSelectButtonHandlerScript : MonoBehaviour
{
    [SerializeField] Button level1Button;
    [SerializeField] Button level2Button;
    [SerializeField] Button level3Button;
    [SerializeField] Button UpgradeMenuButton;
    [SerializeField] TMP_Text lore1Text;
    [SerializeField] TMP_Text lore2Text;
    [SerializeField] TMP_Text lore3Text;
    [SerializeField] Image level2Blocker;
    [SerializeField] Image level3Blocker;

    private string blockerName;

    private List<int> loreCount;
    public int currLevel;


    void Start()
    {

        // Add hover event triggers to buttons
        AddHoverEventTrigger(level1Button, lore1Text, 1);
        AddHoverEventTrigger(level2Button, lore2Text, 2);
        AddHoverEventTrigger(level3Button, lore3Text, 3);

        // Add click event listeners to buttons
        level1Button.onClick.AddListener(ClickedLevel1);
        level2Button.onClick.AddListener(ClickedLevel2);
        level3Button.onClick.AddListener(ClickedLevel3);

        currLevel = Level1EndScript.level1endHandler.currLevel;
        Debug.Log("CURRENT BLOCKED LEVEL: " + currLevel);
        if (currLevel == 2)
        {
            level2Blocker.enabled = false;
        }
        else if (currLevel == 3)
        {
            level2Blocker.enabled = false;
            level3Blocker.enabled = false;
        }   
    }

    void AddHoverEventTrigger(Button button, TMP_Text loreText, int levelIndex)
    {
        // Create a new EventTrigger component
        EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();

        // Add PointerEnter event
        EventTrigger.Entry entryEnter = new EventTrigger.Entry();
        entryEnter.eventID = EventTriggerType.PointerEnter;
        entryEnter.callback.AddListener((eventData) => HoveredLevel(loreText, levelIndex));
        trigger.triggers.Add(entryEnter);

        // Add PointerExit event
        EventTrigger.Entry entryExit = new EventTrigger.Entry();
        entryExit.eventID = EventTriggerType.PointerExit;
        entryExit.callback.AddListener((eventData) => RestoreLoreText(loreText));
        trigger.triggers.Add(entryExit);
    }

    void HoveredLevel(TMP_Text loreText, int levelIndex)
    {

        loreCount = LogCounter.LogsInstance.LogCounts;
        loreText.SetText(loreCount[levelIndex].ToString() + "/2");
    }

    void RestoreLoreText(TMP_Text loreText)
    {
        // Restore original lore text
        loreText.SetText("---"); 
    }

    public void ClickedLevel1()
    {
        Debug.Log("Loading scene: Level 1");
        SceneManager.LoadScene("Level 1");
    }

    public void ClickedLevel2()
    {
        Debug.Log("Loading scene: Level 2");
        SceneManager.LoadScene("Level 2");
    }

    public void ClickedLevel3()
    {
        Debug.Log("Loading scene: Level 3");
        SceneManager.LoadScene("Level 3");
    }

    public void ClickedUpgradeMenu() {
        Debug.Log("Loading scene: Upgrade Menu");
        SceneManager.LoadScene("Upgrade Menu");
    }
    /*private void Start()
    {
        Button selectLevel1 = level1Button.GetComponent<Button>();
        selectLevel1.onClick.AddListener(ClickedLevel1);

        Button selectLevel2 = level2Button.GetComponent<Button>();
        selectLevel2.onClick.AddListener(ClickedLevel2);

        Button selectLevel3 = level3Button.GetComponent<Button>();
        selectLevel3.onClick.AddListener(ClickedLevel3);
    }

    // TODO: need to add locks to uncompleted levels
    void ClickedLevel1()
    {
        loreCount = LogCounter.LogsInstance.LogCounts;
        CURR_LEVEL = LogCounter.LogsInstance.CURR_LEVEL;
        lore1Text.SetText(loreCount[CURR_LEVEL].ToString() + "/2");

        Debug.Log("Loading scene: Level 1");
        SceneManager.LoadScene("Level 1");
    }

    void ClickedLevel2()
    {
        loreCount = LogCounter.LogsInstance.LogCounts;
        CURR_LEVEL = LogCounter.LogsInstance.CURR_LEVEL;
        lore2Text.SetText(loreCount[1].ToString() + "/2");

        Debug.Log("Loading scene: Level 2");
        SceneManager.LoadScene("Level 2");
    }

    void ClickedLevel3()
    {
        loreCount = LogCounter.LogsInstance.LogCounts;
        CURR_LEVEL = LogCounter.LogsInstance.CURR_LEVEL;
        lore3Text.SetText(loreCount[2].ToString() + "/2");

        Debug.Log("Loading scene: Level 3");
        SceneManager.LoadScene("Level 3");
    }*/
}
