using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Quest", menuName = "Game Systems/Quests")]
public class QuestData : ScriptableObject
{
    public enum RewardType
    {
        Currency,
        Reputation,
        Reagent
    }

    public int questID;
    
    [TextArea(15, 20)]
    public string questDescription;
    public string questObjective;
    public int objQuantity;

    public bool isTimed;
    public int questTimer;
    public bool isActive;
    public bool isComplete;

    public int rewardAmount;
    public Sprite rewardImg;
    public RewardType rewardType;
}
