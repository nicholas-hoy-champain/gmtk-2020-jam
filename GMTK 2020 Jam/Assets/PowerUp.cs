using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    public int type;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.FindObjectOfType<WizardController>().powers[type].SetActive(true);
        GameObject.FindObjectOfType<WizardController>().powerIcon[type].color = new Color(GameObject.FindObjectOfType<WizardController>().powerIcon[type].color.r, GameObject.FindObjectOfType<WizardController>().powerIcon[type].color.g, GameObject.FindObjectOfType<WizardController>().powerIcon[type].color.b,1);
        Destroy(this.gameObject);
    }
}
