using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuestTracker : MonoBehaviour
{
    [SerializeField]
    private List<QuestData> quests;

    private void Awake()
    {
        quests = new List<QuestData>();
        
    }

    private void Start()
    {
        // var q = ScriptableObject.CreateInstance<QuestData>();
        // q.description = "A quest from the Quest Tracker.";
        // AddQuest(q);
        var allQuests = Resources.LoadAll<QuestData>("Quests");
        foreach (var quest in allQuests)
        {
            AddQuest(quest);
        }
    }

    void Update()
    {
        if (!IsEmpty() && IsComplete())
        {
            Dequeue();
        }
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

    public QuestData CurrentQuest() => Peek();
    public bool IsComplete() => CurrentQuest().isComplete;
    public bool IsEmpty() => quests.Count == 0;
    public List<QuestData> GetQuests() => quests;
}
