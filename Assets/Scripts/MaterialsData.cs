using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Material", menuName = "Item System/Database/Materials")]

public class MaterialsData : ScriptableObject
{
    public enum MaterialsType
    {
        Herb
    }
    public enum MaterialsQuality
    {
        Junk,
        Common,
        Uncommon,
        Rare
    }
    public MaterialsType materialType;
    public MaterialsQuality materialQuality;
    public int materialID;
    public Sprite materialImg;

    public bool isStackable;
    public int stackableQty;

    [TextArea(15, 20)]
    public string materialDescription;


}
