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
    private Lootable lootable;
    
    public float labelWidth = 150f;
    
    [MenuItem("Game/Loot Creator")]
    public static void ShowWindow()
    {
        EditorWindow window = GetWindow(typeof(LootCreatorEditor));
        Texture icon = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Art/editor_icons/loot.png");
        GUIContent titleContent = new GUIContent("Loot Creator", icon);
        window.titleContent = titleContent;
    }

    private void OnEnable()
    {
        CreateLootableInstance();
    }

    private void OnGUI()
    {
        DisplayLootableOptions();

        GUILayout.Space(20f);
        if (GUILayout.Button("Save"))
        {
            SaveLootable();
            ClearForm();
        }
    }

    void CreateLootableInstance()
    {
        lootable = CreateInstance<Lootable>();
        lootable.itemType = itemType;
    }

    void SaveLootable()
    {
        lootable.GenerateId();                 // TODO: Automate this.
        
        // Finally, save the new asset to the specified location.
        var path = String.Format(assetsPath, lootable.itemId);
        var newTitle = AssetDatabase.GenerateUniqueAssetPath(path);
        AssetDatabase.CreateAsset(lootable, newTitle);
        AssetDatabase.SaveAssets();
    }

    void ClearForm()
    {
        CreateLootableInstance();
    }

    void DisplayLootableOptions()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Loot Options", EditorStyles.boldLabel);
        GUILayout.EndHorizontal();
        GUILayout.Space(20f);
        
        GUILayout.BeginHorizontal();
        GUILayout.Label("Item Name", GUILayout.Width(labelWidth));
        lootable.itemName = EditorGUILayout.TextField(lootable.itemName);
        GUILayout.EndHorizontal();
        
        GUILayout.Space(5);
        
        GUILayout.BeginHorizontal();
        GUILayout.Label("Description", GUILayout.Width(labelWidth));
        lootable.itemDescription = EditorGUILayout.TextArea(lootable.itemDescription,GUILayout.Height(100));
        GUILayout.EndHorizontal();
        
        GUILayout.Space(5);
        
        GUILayout.BeginHorizontal();
        GUILayout.Label("Icon", GUILayout.Width(labelWidth));
        lootable.icon = EditorGUILayout.ObjectField(lootable.icon, typeof(Sprite), true) as Sprite;
        GUILayout.EndHorizontal();
        
    }
}