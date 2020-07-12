using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalShieldPower : MonoBehaviour
{
    public WizardController wizardController;
    public float manaCostPerSecond;
    SpriteRenderer spriteRenderer;
    bool drained;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        drained = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (manaCostPerSecond > wizardController.currentMana)
            drained = true;
        else if (manaCostPerSecond * 2 <= wizardController.currentMana)
            drained = false;

        if (!wizardController.possessed && !wizardController.busy && manaCostPerSecond <= wizardController.currentMana && !drained)
        {
            CheckForInput();
        }
        else if(wizardController.normalShielding)
        {
            TurnOffShielding();
        }
    }

    void CheckForInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            TurnOnShielding();
        }
        else if (wizardController.normalShielding)
        {
            TurnOffShielding();
        }
    }

    void TurnOnShielding()
    {
        wizardController.currentMana -= manaCostPerSecond * Time.deltaTime; 
        wizardController.normalShielding = true;
        spriteRenderer.enabled = true;
    }

    void TurnOffShielding()
    {
        wizardController.normalShielding = false;
        spriteRenderer.enabled = false;
    }
}
