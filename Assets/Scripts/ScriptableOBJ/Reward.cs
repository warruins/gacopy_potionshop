using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Reward : ScriptableObject
{
    [SerializeField]
    private GameItem[] m_items;

    void AddItem(GameItem item)
    {
        m_items.Append(item);
    }
}
