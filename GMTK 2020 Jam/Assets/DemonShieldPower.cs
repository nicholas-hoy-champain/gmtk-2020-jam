using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonShieldPower : MonoBehaviour
{
    public WizardController wizardController;
    public float manaCost;
    public float timeShield;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!wizardController.possessed && !wizardController.busy && manaCost <= wizardController.currentMana)
        {
            CheckForInput();
        }
    }

    void CheckForInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(InitiateDemonShield());
        }
    }

    IEnumerator InitiateDemonShield()
    {
        wizardController.currentMana -= manaCost;
        wizardController.demonShielding = true;
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(timeShield);
        wizardController.demonShielding = false;
        spriteRenderer.enabled = false;
    }
}
