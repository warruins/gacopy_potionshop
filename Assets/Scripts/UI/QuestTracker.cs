﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuestTracker : MonoBehaviour
{
    /**
     * Keeps track of ALL quests, not just active ones. A resource for adding
     * dynamic gameplay.
     */
    [SerializeField]
    private List<QuestData> quests;

    public bool debug;
    public int dQuestCount;
    private void Awake()
    {
        quests = new List<QuestData>();
    }

    private void Start()
    {
        if (debug)
        {
            LoadDebugData();
        }
        else
        {
            LoadQuests();
        }
    }

    void Update()
    {
        if (!IsEmpty() && IsComplete())
        {
            Dequeue();
        }
    }

    void GetCurrentQuests()
    {
        var playerQuests = PlayerPrefs.GetString("CurrentQuests");
    }
    
    public void AddQuest(QuestData quest)
    {
        Enqueue(quest);
    }

    public void Enqueue(QuestData quest)
    {
        quests.Add(quest);
    }

    public void Dequeue()
    {
        quests.Remove(quests[0]);
    }

    public QuestData Peek()
    {
        return quests[0];
    }

    public void RemoveNextQuest(QuestData quest)
    {
        Dequeue();
    }

    private void LoadQuests()
    {
        var allQuests = Resources.LoadAll<QuestData>("Quests");
        foreach (var quest in allQuests)
        {
            AddQuest(quest);
        }
    }

    private void LoadDebugData()
    {
        for (int i = 0; i < dQuestCount; i++)
        {
            var q = ScriptableObject.CreateInstance<QuestData>();
            q.description = $"Quest {i} from the Quest Tracker.";
            AddQuest(q);
        }
    }
    
    public QuestData CurrentQuest() => Peek();
    public bool IsComplete() => CurrentQuest().isComplete;
    public bool IsEmpty() => quests.Count == 0;
    public List<QuestData> GetQuests() => quests;
}
