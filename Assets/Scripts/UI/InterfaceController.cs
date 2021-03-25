using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    public Canvas ledgerWindow;
    public Canvas spellbookWindow;
    private bool ledgerActive;
    private bool spellbookActive;
    
    void Start()
    {
        ledgerActive = false;
        spellbookActive = false;
    }

    public void ToggleLedger() {
        ledgerActive = !ledgerActive;
        ledgerWindow.gameObject.SetActive(ledgerActive);
    }

    public void ToggleSpellbook()
    {
        spellbookActive = !spellbookActive;
        spellbookWindow.gameObject.SetActive(spellbookActive);
    }
}
