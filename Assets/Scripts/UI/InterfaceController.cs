﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    //public Button ledgerShowHide;
    public Canvas ledgerWindow;
    private bool ledgerActive;
    // Start is called before the first frame update
    void Start()
    {
        ledgerActive = false;
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void ShowHideLedger() {
        //ledgerWindow.gameObject.SetActive(true);
        ledgerActive = !ledgerActive;

        ledgerWindow.gameObject.SetActive(ledgerActive);
    }
}
