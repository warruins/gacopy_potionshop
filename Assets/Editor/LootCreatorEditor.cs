using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LootCreatorEditor : EditorWindow
{
    /**
     * Game Item Editor
     * Quick and easy tool to generate new objects within the game.
     */
    // public enum GameContentOptions selection;
    private string assetsPath = "Assets/Resources/Loot/{0}.asset";
    private string itemType = "Loot";
    private string itemName;
    private string itemDescription;
    private Sprite itemIcon;
    
    public float labelWidth = 150f;
    public Lootable lootable;
    
    [MenuItem(("Game/Loot Creator"))]
    public static void ShowWindow()
    {
        EditorWindow window = GetWindow(typeof(LootCreatorEditor));
        Texture icon = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Art/editor_icons/loot.png");
        GUIContent titleContent = new GUIContent("Loot Creator", icon);
        window.titleContent = titleContent;
    }

    private void OnGUI()
    {
        DisplayQuestOptions();

        GUILayout.Space(20f);
        if (GUILayout.Button("Save"))
        {
            CreateNewLoot();
            ClearForm();
        }
    }

    void CreateNewLoot()
    {
        // Create a new Quest ScriptableObject
        Lootable loot = CreateInstance<Lootable>();
        
        // Update its properties with the form information
        loot.itemType = itemType;
        loot.itemName = itemName;  // TODO: Clean this double naming thing up!
        loot.itemDescription = itemDescription;
        loot.icon = itemIcon;
        // Now that the info is entered on the quest, generate an ID with it.
        loot.GenerateId();                 // TODO: Automate this.
        
        // Finally, save the new asset to the specified location.
        var path = String.Format(assetsPath, loot.itemId);
        var newTitle = AssetDatabase.GenerateUniqueAssetPath(path);
        AssetDatabase.CreateAsset(loot, newTitle);
        AssetDatabase.SaveAssets();
    }

    void ClearForm()
    {
        itemName = EditorGUILayout.TextField("");
        itemDescription = EditorGUILayout.TextField("");
    }

    void DisplayQuestOptions()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Loot Options", EditorStyles.boldLabel);
        GUILayout.EndHorizontal();
        GUILayout.Space(20f);
        
        GUILayout.BeginHorizontal();
        GUILayout.Label("Item Name", GUILayout.Width(labelWidth));
        itemName = EditorGUILayout.TextField(itemName);
        GUILayout.EndHorizontal();
        
        GUILayout.Space(5);
        
        GUILayout.BeginHorizontal();
        GUILayout.Label("Description", GUILayout.Width(labelWidth));
        itemDescription = EditorGUILayout.TextArea(itemDescription,GUILayout.Height(100));
        GUILayout.EndHorizontal();
        
        GUILayout.Space(5);
        
        GUILayout.BeginHorizontal();
        GUILayout.Label("Icon", GUILayout.Width(labelWidth));
        itemIcon = EditorGUILayout.ObjectField(itemIcon, typeof(Sprite), true) as Sprite;
        GUILayout.EndHorizontal();
        
    }
}