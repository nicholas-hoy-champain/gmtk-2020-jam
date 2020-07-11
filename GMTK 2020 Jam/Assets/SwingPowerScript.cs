using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SwingPowerScript : MonoBehaviour
{
    public WizardController wizardController;

    public float manaCost = 10;

    public float rotationRange;
    public GameObject swungObject;
    public float timeToSwing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!wizardController.possessed && !wizardController.busy && manaCost <= wizardController.currentMana)
        {
            CheckForInput();
        }
    }

    void CheckForInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(SwingAttack());
        }
    }

    IEnumerator SwingAttack()
    {
        wizardController.currentMana -= manaCost;
        wizardController.busy = true;
        Instantiate(swungObject, transform.position, transform.rotation);
        yield return timeToSwing;
        wizardController.busy = false;
    }
}
