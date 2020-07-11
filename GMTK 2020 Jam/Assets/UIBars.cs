using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBars : MonoBehaviour
{
    public WizardController wizardController;
    public Image healthBar;
    public Image manaBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = wizardController.health / wizardController.healthMax;
        manaBar.fillAmount = wizardController.currentMana / wizardController.manaMax;
    }
}
