using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public GameObject demonSoulPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (!GameObject.FindObjectOfType<WizardController>().possessed)
            {
                Instantiate(demonSoulPrefab, transform.position, transform.rotation);
            }
            Destroy(this.gameObject);
        }
    }
}