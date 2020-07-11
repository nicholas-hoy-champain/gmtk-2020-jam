using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbPowerScript : MonoBehaviour
{
    public float absorptionRadius = 1.5f;
    public WizardController wizardController;

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInput();
    }

    void CheckForInput()
    {
        if(Input.GetMouseButton(1) && !wizardController.possessed)
        {
            CheckForDemonSoul();
        }
        else if(Input.GetMouseButtonUp(1) || wizardController.possessed)
        {
            sr.enabled = false;
        }
    }

    void CheckForDemonSoul()
    {
        sr.enabled = true;
        foreach(DemonSoulController obj in GameObject.FindObjectsOfType<DemonSoulController>())
        {
            if (Mathf.Abs(Vector3.Distance(transform.position, obj.transform.position)) <= absorptionRadius)
            {
                wizardController.GainCorruption(obj);
                Destroy(obj.gameObject);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, absorptionRadius);
    }
}
