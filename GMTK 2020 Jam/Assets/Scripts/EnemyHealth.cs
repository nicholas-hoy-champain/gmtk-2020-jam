using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public GameObject demonSoulPrefab;
    public float HitIndicatorTime;
    public Material[] material;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    // Update is called once per frame
    void Update()
    {

    }

    void HitAnim()
    {
        rend.sharedMaterial = material[0];
    }

    public void TakeDamage(float damage)
    {
        rend.sharedMaterial = material[1];
        health -= damage;
        if (health <= 0)
        {
            if (!GameObject.FindObjectOfType<WizardController>().possessed)
            {
                Instantiate(demonSoulPrefab, transform.position, transform.rotation);
            }
            Destroy(this.gameObject);
        }
        Invoke("HitAnim", 0.1f);
    }
}