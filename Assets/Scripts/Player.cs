using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerData settings;
    [SerializeField] private Inventory inventory;
    public Image avatar;
    public Text playerName;

    public Text gold;

    void Start()
    {
        playerName.text = settings.playerName;
        // TODO: Sprite not there visually but its being loaded on inspector. why?
        avatar.sprite = settings.sprite;
        inventory = settings.inventory;
        gold.text = settings.goldOwned.ToString();
    }
}
