using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LogCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text logCounter;
    [SerializeField] private TMP_Text loreText;
    public static LogCounter LogsInstance;
<<<<<<< Updated upstream
    private List<int> logCounts = new List<int> { 0, 0, 0, 0 }; // 1 - indexed
    // public int CURR_LEVEL = 0;
    public int currLevel;
    private List<int> logCountPerLevel = new List<int> { 0, 2, 2, 2 };
=======
    private List<int> logCounts = new List<int> { 0, 0, 0, 0 };
    public int CURR_LEVEL = 0;
    private List<int> logCountPerLevel = new List<int> { 0, 2, 2, 2 };

    private string[] loreStories = new string[]
    {
        "In the final days before the collapse, the government issued one last broadcast. It was a message of hope, a plea for unity in the face of inevitable destruction. But as the signals crackled and faded into silence, so did the last vestige of order. The broadcast is still found playing on a loop in some parts of the city, a ghostly reminder of what was lost.",
        "Amidst the desolation, a lone rooftop garden tells a story of resistance. It belonged to an old botanist, who believed in life amidst death. He cultivated this garden until his last breath, hoping to see greenery take back the city. The garden thrives, untended but resilient, a beacon of life in a dead world.",
        "Deep within the city lies a wall covered in graffiti, known as the Wall of Voices. It's said that when the chaos began, people came here to leave messages for loved ones, hoping they would find them. Now, it serves as a tapestry of despair and longing, a mosaic of the many lives torn apart",
        "Beneath the city lies a forgotten subway system, once the lifeblood of the metropolis. Now, its trains are stalled, stations deserted. In one car, a diary sits on a seat, untouched. It belongs to a teenager who documented their daily struggles to find food and safety as society crumbled around them. The last entry is hopeful, believing in a better tomorrow.",
        "In the city's heart, a factory once produced the machines of war that led to its downfall. Now, it stands silent, but for a single, operational robot. Programmed for maintenance, it continues its tasks, unaware its purpose has long vanished. It's a somber reflection on the automation that once promised progress but brought ruin instead.",
        "Hidden within the city is an oasis, a small, clean water source surrounded by vegetation. It's guarded by a community of survivors who discovered it early on. The oasis is a rare piece of paradise, a reminder of the world before the fall. Stories say the community is working on a plan to purify more water sources, hoping to rebuild what was lost"
    };
>>>>>>> Stashed changes

    private void OnEnable()
    {
        Lore.onPlayerCollectLogEvent += AddLog;
        // Event.onPlayerCollectLogEvent += AddLog;
    }

    private void OnDisable()
    {
        Lore.onPlayerCollectLogEvent -= AddLog;
        // Event.onPlayerCollectLogEvent -= AddLog;
    }

    private void Awake()
    {
        LogsInstance = this;
    }

    private void Start()
    {
<<<<<<< Updated upstream
        currLevel = PlayerController.PlayerInstance.currLevel;
        Debug.Log("CURRLEVEL:" + currLevel);
        logCounter.SetText(logCounts[currLevel].ToString() + "/" + logCountPerLevel[currLevel].ToString());
=======
        Debug.Log(logCounts[0]);
        logCounter.SetText(logCounts[CURR_LEVEL].ToString() + "/" + logCountPerLevel[CURR_LEVEL].ToString());


>>>>>>> Stashed changes
    }

    // Public property to access the data
    public List<int> LogCounts
    {
        get { return logCounts; }
        set { logCounts = value; }
    }


    private void AddLog(Lore events) // argument should be EventScript event
    {
        LogCounter thisScript = new LogCounter();
        Debug.Log("Log collection event heard");
        logCounts[currLevel]++;
        thisScript.LogCounts = logCounts;
        logCounter.SetText(logCounts[currLevel].ToString() + "/" + logCountPerLevel[currLevel].ToString());
    }

    public void DisplayLore(int chapter)
    {

        string storiesToShow = loreStories[chapter];

        loreText.text = storiesToShow;
    }
}
