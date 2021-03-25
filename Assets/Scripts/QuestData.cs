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

    public string questID;
    
    [TextArea(15, 20)]
    public string description;

    public Sprite icon;
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
