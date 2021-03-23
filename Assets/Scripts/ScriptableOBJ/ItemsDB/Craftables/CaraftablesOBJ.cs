using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftablesObject : CraftablesData
{
    public void Awake()
    {
        craftableType = CraftableType.Potion;
    }
}
