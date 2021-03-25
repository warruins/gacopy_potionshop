using System;
using System.Collections;
using System.Collections.Generic;
using Packages.Rider.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameItem : ScriptableObject
{
    [ReadOnlyField] public string itemId;
    [ReadOnlyField] private string UID;
    [ReadOnlyField] public string itemName;
    public string itemType;

    [TextArea(15, 20)]
    public string itemDescription;
    public Sprite icon;

    public void OnValidate()
    {
        if (string.IsNullOrEmpty(itemId))
        {
            GenerateId();
            EditorUtility.SetDirty(this);
        }
    }
    
    public void GenerateId()
    {
        UID = Guid.NewGuid().ToString();
        string[] nameParts = itemName.Split(' ');
        itemId = itemType;
        foreach (string word in nameParts)
        {
            itemId += $"-{word}";
        }
        itemId += $"-{UID}";
    }
}
