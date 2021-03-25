using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerData settings;
    public SpriteRenderer spriteRenderer;
    public Text playerName;
    public Sprite sprite;
    private Inventory inventory;

    public Text gold;

    void Start()
    {
        playerName.text = settings.name;
        // TODO: Sprite not rendering. why?
        sprite = settings.playerImg;
        spriteRenderer.sprite = sprite;
        inventory = settings.inventory;
        gold.text = settings.goldOwned.ToString();
    }
}
