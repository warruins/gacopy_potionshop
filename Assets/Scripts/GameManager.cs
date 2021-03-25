using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /** Game Manager
     * The manager keeps global game status to do things like share data with the player
     * between scenes and track player progress between scenes.
     *
     * This will pull data for each scene from wherever its stored and make it available to
     * all scenes.
     */
    public Player player;
    public List<QuestData> playerQuests;

    private void Start()
    {
        LoadPlayerQuests();
        LoadPlayer();
    }

    void LoadPlayerQuests()
    {
        
    }

    void LoadPlayer()
    {
        
    }
}
