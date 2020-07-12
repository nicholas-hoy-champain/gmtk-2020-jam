using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawPower : MonoBehaviour
{
    public WizardController wizardController;
    public float manaCost = 10;
    public GameObject swungObject;
    public float timeToSwing;

    // Start is called before the first frame update
    void Start()
    {
        
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(SwingAttack());
        }
    }

    IEnumerator SwingAttack()
    {
        wizardController.currentMana -= manaCost;
        wizardController.busy = true;
        Instantiate(swungObject, transform);
        yield return new WaitForSeconds(timeToSwing);
        wizardController.busy = false;
    }
}
