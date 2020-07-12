using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandminePower : MonoBehaviour
{
    public WizardController wizardController;
    public GameObject landminePrefab;
    public float manaCost;
    public float timeToThrow;
    public KeyCode key;

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
        if(Input.GetKeyDown(key))
        {
            ThrowTrap();
        }
    }

    void ThrowTrap()
    {
        wizardController.currentMana -= manaCost;
        Instantiate(landminePrefab, transform.position, transform.rotation);
    }

    IEnumerator BusyTime()
    {
        wizardController.busy = true;
        yield return timeToThrow;
        wizardController.busy = false;
    }
}
