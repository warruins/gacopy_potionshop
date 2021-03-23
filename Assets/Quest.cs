using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public Image icon;
    public Text description;
    public String objective;
    public int objQuantity;
    private Inventory inventory;

    public bool isAccepted;
    public bool isComplete;
    [SerializeField]
    private QuestData settings;
    

    public Text reward; // not sure what this is yet.

    private void Awake()
    {
        description.text = settings.questDescription;
        objective = settings.questObjective;
        objQuantity = settings.objQuantity;
    }
    
    public void CheckProgress()
    {
        // TODO: Figure out how to use inventory here!
        // find items in inventory
        var item = inventory.FindItem(objective);
        // compare the count to the objective quantity
        if (item.storedQuantity >= objQuantity)
        {
            isComplete = true;
        }
    }

    public bool IsComplete() => isComplete;
}

