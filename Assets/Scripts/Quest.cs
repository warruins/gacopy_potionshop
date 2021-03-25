using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    [Header("UI Settings")]
    public QuestData settings;
    public Image icon;
    public Image rewardIcon;
    public Text description;
    public Text reward; // not sure what this is yet.
    public String rewardAmount;
    public Button questButton;
    public Text buttonText;
    [SerializeField] private Inventory inventory; // TODO: this should live on the player or manager.
    
    [Header("Status")]
    public String objective;
    public int objQuantity;
    [SerializeField] private bool accepted;
    [SerializeField] private bool complete;
    
    private Image buttonImage;
    
    private void Start()
    {
        icon.sprite = settings.icon;
        description.text = settings.description;
        reward.text = $"{settings.rewardAmount} {settings.rewardType.ToString()}";
        rewardIcon.sprite = settings.rewardImg;
        objective = settings.objective;
        objQuantity = settings.quantity;
        buttonImage = questButton.GetComponent<Image>();
    }

    private void Update()
    {
        if (IsAccepted())
        {
            buttonText.text = "Deliver";
            buttonImage.color = Color.green;
            questButton.interactable = false;
        }

        if (IsComplete() && IsAccepted())
        {
            buttonText.text = "Deliver";
            questButton.interactable = true;
        }
    }

    public void CheckProgress()
    {
        // TODO: Figure out how to use inventory here!
        // find items in inventory
        var item = inventory.FindItem(objective);
        // compare the count to the objective quantity
        if (item.storedQuantity >= objQuantity)
        {
            complete = true;
        }
    }

    public void AcceptQuest()
    {
        accepted = true;
    }

    public bool IsComplete() => complete;
    public bool IsAccepted() => accepted;
}

