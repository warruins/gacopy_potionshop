using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LedgerWindowController : MonoBehaviour
{
    public QuestTracker tracker;
    public Canvas questContainer;
    public Quest[] questContainers;
    public Transform ledgerPos;

    void Start()
    {
        questContainers = GetComponentsInChildren<Quest>();
        GetQuests();
        // Debug.Log("Container 1:", questContainers[0]);
    }

    /**
     * Get Quests
     * Solves the problem of how to iterate over the list of possible quests and
     * display them on the page. If we limit the Ledger to 3 quests, then we can use
     * a static number of containers (3) and simply add the data into them one at a time.
     * TODO: List accepted quests and new quests (currently lists all).
     */
    void GetQuests()
    {
        List<QuestData> trackerQuests = tracker.GetQuests();
        for (int i = 0; i < questContainers.Length; i++)
        {
            var quest = trackerQuests[i];
            questContainers[i].settings = quest;
        }
    }
    
    /**
     * Display Quests
     * Dynamically creates quest containers for each quest on the tracker. The Ledger
     * would start empty and this method would add new containers.
     * TODO: Positioning seems tricky for this. Long term goal.
     */
    void DisplayQuests()
    {
        var quests = tracker.GetQuests();
        
        foreach (var quest in quests)
        {
            // TODO: Fix position of the new containers. Resets to anchor left bottom instead of top and needs to drop down about 2x the height of the container.
            var container = Instantiate(questContainer);
            container.transform.SetParent(transform, false);
            container.transform.position += new Vector3(0, -60);
            // container.transform.position = ledgerPos.position;
            // container.transform.localScale = new Vector3(1, 1, 1);
            var q = container.GetComponent<Quest>();
            q.settings = quest;
        }
    }
}
