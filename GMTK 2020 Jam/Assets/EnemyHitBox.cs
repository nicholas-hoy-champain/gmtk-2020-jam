using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{
    public float damage;
    public float radiusOfDamage;
    public float life;
    public Transform orgin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Collider2D obj in Physics2D.OverlapCircleAll(transform.position, radiusOfDamage))
        {
            if (obj.tag == "Player")
            {
                obj.GetComponent<WizardController>().TakeDamage(damage,orgin);
                Destroy(this.gameObject);
            }
        }

        life -= Time.deltaTime;

        if(life < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
