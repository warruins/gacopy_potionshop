﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public Image icon;
    public Text description;
    public Text reward; // not sure what this is yet.
    public String rewardAmount;
    public Image rewardIcon;
    public String objective;
    public int objQuantity;
    private Inventory inventory;

    public bool isAccepted;
    public bool isComplete;
    
    [SerializeField]
    public QuestData settings;
    
    private void Start()
    {
        description.text = settings.description;
        reward.text = settings.rewardType.ToString();
        rewardIcon.sprite = settings.rewardImg;
        objective = settings.objective;
        objQuantity = settings.quantity;
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

