using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTracker : MonoBehaviour
{
    private Queue<Quest> quests;

    private void Awake()
    {
        quests = new Queue<Quest>();
    }

    void Update()
    {
        if (IsComplete())
        {
            quests.Dequeue();
        }
    }

    public void AddQuest(Quest quest)
    {
        quests.Enqueue(quest);
    }

    public void RemoveNextQuest(Quest quest)
    {
        quests.Dequeue();
    }
    
    public Quest CurrentQuest() => quests.Peek();
    public bool IsComplete() => CurrentQuest().IsComplete();
}
