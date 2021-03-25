using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ItemGeneratorEditor : EditorWindow
{
    /**
     * Game Item Editor
     * Quick and easy tool to generate new objects within the game.
     */
    // public enum GameContentOptions selection;
    private string assetsPath = "Assets/Resources/Quests/{0}.asset";
    enum GameContentOptions { Potion, Quest }

    private GameContentOptions selected = GameContentOptions.Quest;
    
    // Quest Options
    private string questTitle;
    private string description;
    private string objective;
    private int objectiveQuantity;
    private string reward;
    private int rewardAmount;
    private string rewardImage;
    
    // Potion Options
    private string itemName;
    private string quantity;
    
    [MenuItem(("Game/Item Generator"))]
    public static void ShowWindow()
    {
        GetWindow(typeof(ItemGeneratorEditor));
    }

    private void OnGUI()
    {
        GUILayout.Space(20f);
        GUILayout.Label("Create", EditorStyles.boldLabel);
        
        GUILayout.Space(20f);
        
        GUILayout.BeginHorizontal();
        GUILayout.Label("Content");
        selected = (GameContentOptions)EditorGUILayout.EnumPopup(selected);
        GUILayout.EndHorizontal();
        
        GetContentOption();

        if (GUILayout.Button("Save"))
        {
            CreateNewQuest();
            ClearForm();
        }
    }

    void GetContentOption()
    {
        if (selected == GameContentOptions.Potion)
        {
            DisplayPotionOptions();
        }
        else
        {
            DisplayQuestOptions();
        }
    }
    
    void CreateNewQuest()
    {
        QuestData quest = CreateInstance<QuestData>();
        quest.description = description;
        quest.objective = objective;
        quest.quantity = objectiveQuantity;
        quest.rewardAmount = rewardAmount;
        quest.rewardImg = Resources.Load<Sprite>(rewardImage);
        var path = String.Format(assetsPath, questTitle);
        var newTitle = AssetDatabase.GenerateUniqueAssetPath(path);
        AssetDatabase.CreateAsset(quest, newTitle);
        AssetDatabase.SaveAssets();
    }

    void ClearForm()
    {
        questTitle = EditorGUILayout.TextField("");
        description = EditorGUILayout.TextArea("");
        objective = EditorGUILayout.TextField("");
        quantity = EditorGUILayout.TextField("");
        reward = EditorGUILayout.TextField("");
        rewardAmount = EditorGUILayout.IntField(0);
    }
    
    void DisplayPotionOptions()
    {
        GUILayout.Space(20f);
        
        GUILayout.BeginHorizontal();
        GUILayout.Label("Name");
        itemName = EditorGUILayout.TextField(itemName);
        GUILayout.EndHorizontal();
    }
    
    void DisplayQuestOptions()
    {
        GUILayout.Space(20f);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Quest");
        GUILayout.EndHorizontal();
        
        GUILayout.BeginHorizontal();
        GUILayout.Label("title");
        questTitle = EditorGUILayout.TextField(questTitle);
        GUILayout.EndHorizontal();
        
        GUILayout.BeginHorizontal();
        GUILayout.Label("Description");
        description = EditorGUILayout.TextArea(description, GUILayout.Width(200), GUILayout.Height(100));
        GUILayout.EndHorizontal();
        
        GUILayout.BeginHorizontal();
        GUILayout.Label("Objective");
        objective = EditorGUILayout.TextField(objective);
        GUILayout.EndHorizontal();
        
        GUILayout.BeginHorizontal();
        GUILayout.Label("Objective Quantity");
        objectiveQuantity = EditorGUILayout.IntSlider(objectiveQuantity,0, 100);        
        GUILayout.EndHorizontal();
        
        GUILayout.BeginHorizontal();
        GUILayout.Label("Reward");
        // reward = EditorGUILayout.ObjectField(reward);
        GUILayout.EndHorizontal();
        
        GUILayout.BeginHorizontal();
        GUILayout.Label("Reward Amount");
        rewardAmount = EditorGUILayout.IntField(rewardAmount);
        GUILayout.EndHorizontal();
        
        GUILayout.BeginHorizontal();
        GUILayout.Label("Reward Icon");
        rewardImage = EditorGUILayout.TextField(rewardImage);
        GUILayout.EndHorizontal();
    }
}