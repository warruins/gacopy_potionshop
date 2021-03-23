using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Craftable", menuName = "Item System/Database/Crafted Items")]
public class CraftablesData : ScriptableObject
{
    public enum CraftableType
    {
        Potion
    }

    public CraftableType craftableType;
    public string craftableLabel;
    public int craftableID;
    public Sprite craftableImg;

    [TextArea(15, 20)]
    public string craftableDescription;

    public bool isStackable;
    public int stackableQty;
}
