using System;
using System.Collections;
using System.Collections.Generic;
using Packages.Rider.Editor;
using UnityEngine;

public class GameItem : ScriptableObject
{
    private string id;
    private string itemType;
    private string itemName;
    private string UID;

    protected void GenerateId()
    {
        UID = Guid.NewGuid().ToString();
        string[] nameParts = itemName.Split(' ');
        id = itemType;
        foreach (string word in nameParts)
        {
            id += $"-{word.ToUpper()}";
        }
        id += $"-{UID}";
    }
}
