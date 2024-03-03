using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelSelectButtonHandlerScript : MonoBehaviour
{
    [SerializeField] Button level1Button;
    [SerializeField] Button level2Button;
    [SerializeField] Button level3Button;
    [SerializeField] TMP_Text lore1Text;
    [SerializeField] TMP_Text lore2Text;
    [SerializeField] TMP_Text lore3Text;

    private int loreCount;

    private void Start()
    {
        Button selectLevel1 = level1Button.GetComponent<Button>();
        selectLevel1.onClick.AddListener(ClickedLevel1);

        Button selectLevel2 = level2Button.GetComponent<Button>();
        selectLevel2.onClick.AddListener(ClickedLevel2);

        Button selectLevel3 = level3Button.GetComponent<Button>();
        selectLevel3.onClick.AddListener(ClickedLevel3);
    }

    void ClickedLevel1()
    {
        SampleCollectibles collectibleCount = FindObjectOfType<SampleCollectibles>(); // replace this with the script that has the global lore count variable
        if (collectibleCount != null)
        {
            loreCount = collectibleCount.level1_loreCount;
        }
        lore1Text.SetText(loreCount.ToString() + "/2");
    }

    void ClickedLevel2()
    {
        SampleCollectibles collectibleCount = FindObjectOfType<SampleCollectibles>(); // replace this with the script that has the global lore count variable
        if (collectibleCount != null)
        {
            loreCount = collectibleCount.level2_loreCount;
        }
        lore2Text.SetText(loreCount.ToString() + "/2");
    }

    void ClickedLevel3()
    {
        SampleCollectibles collectibleCount = FindObjectOfType<SampleCollectibles>(); // replace this with the script that has the global lore count variable
        if (collectibleCount != null)
        {
            loreCount = collectibleCount.level3_loreCount;
        }
        lore3Text.SetText(loreCount.ToString() + "/2");
    }
}
