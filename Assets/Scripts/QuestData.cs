using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "new Quest", menuName = "Game Systems/Quests")]
public class QuestData : GameItem
{
    public enum RewardType
    {
        Currency,
        Reputation,
        Reagent
    }
    [ReadOnlyField] public string questID;
    
    // [TextArea(15, 20)]
    // public string itemDescription;
    public string questTitle;

    // public Sprite icon;
    public string objective;
    public int quantity;

    public bool isTimed;
    public int questTimer;
    public bool isActive;
    public bool isComplete;

    public int rewardAmount;
    public Sprite rewardImg;
    public RewardType rewardType;
}
