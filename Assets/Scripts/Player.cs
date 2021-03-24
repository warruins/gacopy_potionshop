using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerData settings;
    public SpriteRenderer renderer;
    public Text playerName;
    public Sprite sprite;
    private Inventory inventory;

    public Text gold;
    public Text silver;
    public Text copper;

    void Awake()
    {
        playerName.text = settings.name;
        // TODO: Sprite not rendering. why?
        sprite = settings.playerImg;
        renderer.sprite = sprite;
        inventory = settings.inventory;
        gold.text = settings.goldOwned.ToString();
        silver.text = settings.silverOwned.ToString();
        copper.text = settings.copperOwned.ToString();
    }
}
