using System;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class QuestCreatorEditor : EditorWindow
    {
        /**
     * Game Item Editor
     * Quick and easy tool to generate new objects within the game.
     */
        private string assetsPath = "Assets/Resources/Quests/{0}.asset";

        private string itemType = "Quest";
    
        private Sprite questIcon;
        private string questTitle;
        private string description;
        private string objective;
        private GameItem reward;
        private int objectiveQuantity;
        private int rewardAmount;
        private Sprite rewardImage;
   
        private float labelWidth = 150f;
    
        [MenuItem("Game/Quest Creator")]
        public static void ShowWindow()
        {
            EditorWindow window = GetWindow(typeof(QuestCreatorEditor));
            Texture icon = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Art/editor_icons/quest.png");
            GUIContent titleContent = new GUIContent("Quest Creator", icon);
            window.titleContent = titleContent;
        }

        private void OnGUI()
        {
            DisplayQuestOptions();

            GUILayout.Space(20f);
            if (GUILayout.Button("Save"))
            {
                CreateNewQuest();
                ClearForm();
            }
        }

        void CreateNewQuest()
        {
            // Create a new Quest ScriptableObject
            QuestData quest = CreateInstance<QuestData>();
        
            // Update its properties with the form information
            quest.itemType = itemType;
            quest.itemName = questTitle;  // TODO: Clean this double naming thing up!
            quest.questTitle = questTitle;
            quest.itemDescription = description;
            quest.icon = questIcon;
            quest.objective = objective;
            quest.quantity = objectiveQuantity;
            quest.rewardAmount = rewardAmount;
            quest.rewardImg = rewardImage;
        
            // Now that the info is entered on the quest, generate an ID with it.
            quest.GenerateId();                 // TODO: Automate this.
            quest.questID = quest.itemId;
        
            // Finally, save the new asset to the specified location.
            var path = String.Format(assetsPath, quest.questID);
            var newTitle = AssetDatabase.GenerateUniqueAssetPath(path);
            AssetDatabase.CreateAsset(quest, newTitle);
            AssetDatabase.SaveAssets();
        }

        void ClearForm()
        {
            questTitle = EditorGUILayout.TextField("");
            description = EditorGUILayout.TextArea("");
            objective = EditorGUILayout.TextField("");
            objectiveQuantity = EditorGUILayout.IntField(0);
            rewardAmount = EditorGUILayout.IntField(0);
        }
    
        void DisplayQuestOptions()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Quest Options", EditorStyles.boldLabel);
            GUILayout.EndHorizontal();
            GUILayout.Space(20f);
        
            GUILayout.BeginHorizontal();
            GUILayout.Label("Title", GUILayout.Width(labelWidth));
            questTitle = EditorGUILayout.TextField(questTitle);
            GUILayout.EndHorizontal();
        
            GUILayout.Space(5);
        
            GUILayout.BeginHorizontal();
            GUILayout.Label("Description", GUILayout.Width(labelWidth));
            description = EditorGUILayout.TextArea(description,GUILayout.Height(100));
            GUILayout.EndHorizontal();
        
            GUILayout.Space(5);
        
            GUILayout.BeginHorizontal();
            GUILayout.Label("Quest Icon", GUILayout.Width(labelWidth));
            questIcon = EditorGUILayout.ObjectField(questIcon,typeof(Sprite), true) as Sprite;
            GUILayout.EndHorizontal();
        
            GUILayout.Space(5);
        
            GUILayout.BeginHorizontal();
            GUILayout.Label("Objective", GUILayout.Width(labelWidth));
            objective = EditorGUILayout.TextField(objective);
            GUILayout.EndHorizontal();
        
            GUILayout.Space(5);
        
            GUILayout.BeginHorizontal();
            GUILayout.Label("Objective Quantity", GUILayout.Width(labelWidth));
            objectiveQuantity = EditorGUILayout.IntSlider(objectiveQuantity,0, 100);        
            GUILayout.EndHorizontal();
        
            GUILayout.Space(5);
        
            GUILayout.BeginHorizontal();
            GUILayout.Label("Reward", GUILayout.Width(labelWidth));
            reward = EditorGUILayout.ObjectField(reward, typeof(GameItem), true) as GameItem;
            GUILayout.EndHorizontal();
        
            GUILayout.Space(5);
        
            GUILayout.BeginHorizontal();
            GUILayout.Label("Reward Amount", GUILayout.Width(labelWidth));
            rewardAmount = EditorGUILayout.IntField(rewardAmount);
            GUILayout.EndHorizontal();
        
            GUILayout.Space(5);
        
            GUILayout.BeginHorizontal();
            GUILayout.Label("Reward Icon", GUILayout.Width(labelWidth));
            rewardImage = EditorGUILayout.ObjectField(rewardImage, typeof(Sprite), true) as Sprite;
            GUILayout.EndHorizontal();
        }
    }
}