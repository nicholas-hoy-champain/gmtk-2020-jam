using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportExplosionController : MonoBehaviour
{
    public float damage;
    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Collider2D obj in Physics2D.OverlapCircleAll(transform.position, radius))
        {
            if (obj.tag == "Enemy")
            {
                obj.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
