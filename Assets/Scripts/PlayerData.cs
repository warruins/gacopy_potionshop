using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Game Systems/Player")]
public class PlayerData : ScriptableObject
{
    public string playerName;
    public Sprite sprite;
    public string playerTitle;

    public int goldOwned;
    public int silverOwned;
    public int copperOwned;

    public Inventory inventory;
}
