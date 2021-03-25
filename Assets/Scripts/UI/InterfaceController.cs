using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    public Canvas ledgerWindow;
    private bool ledgerActive;
    
    void Start()
    {
        ledgerActive = false;
    }

    public void ToggleLedger() {
        ledgerActive = !ledgerActive;
        ledgerWindow.gameObject.SetActive(ledgerActive);
    }
}
