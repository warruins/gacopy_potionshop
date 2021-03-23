using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Game Systems/Inventory")]
public class Inventory : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    
    public void AddItem(String itemId, int _itemQuantity)
    {
        bool hasItem = false;
        for(int i = 0; i < Container.Count; i++)
        {
            if(Container[i].itemId == itemId)
            {
                Container[i].AddItem(_itemQuantity);
                hasItem = true;
                break;
            }
        }

        if (!hasItem)
        {
            Container.Add(new InventorySlot(itemId, _itemQuantity));
        }
    }

    public InventorySlot FindItem(string item_id)
    {
        for(int i = 0; i < Container.Count; i++)
        {
            if(Container[i].itemId == item_id)
            {
                return Container[i];
            }
        }

        return null;
    }
}

[System.Serializable]
public class InventorySlot
{
    public string itemId;
    public string name;
    public int storedQuantity;
    public InventorySlot(String itemId, int _itemQuantity) {
        this.itemId = itemId;
        storedQuantity = _itemQuantity;
    }

    public void AddItem(int value) {
        storedQuantity += value;
    }
}