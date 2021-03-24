using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LedgerController : MonoBehaviour
{
    public QuestTracker tracker;
    public Canvas questContainer;

    public Transform ledgerPos;
    // Start is called before the first frame update
    void Start()
    {
        DisplayQuests();
    }

    void DisplayQuests()
    {
        var quests = tracker.GetQuests();
        
        foreach (var quest in quests)
        {
            var container = Instantiate(questContainer);
            container.transform.SetParent(transform, false);
            // container.transform.position = ledgerPos.position;
            var q = container.GetComponent<Quest>();
            q.settings = quest;
        }
    }
}
