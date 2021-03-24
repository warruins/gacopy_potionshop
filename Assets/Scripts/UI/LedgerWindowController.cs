using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LedgerWindowController : MonoBehaviour
{
    public QuestTracker tracker;
    public Canvas questContainer;
    public float questHeight;

    public Transform ledgerPos;
    // Start is called before the first frame update
    void Start()
    {
        // TODO: Figure out how to get the "height" of prefab to add and adjust positions of newly added quests to the ledger.
        // questHeight = questContainer.transform.position.y;
        DisplayQuests();
    }

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
