using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmineController : MonoBehaviour
{
    Rigidbody2D rb;
    bool damaging;
    public float radiusOfTrigger;
    public float radiusOfDamage;
    public float startingVelocity;
    public float timeThrown;
    public float damage;
    bool armed { get { return timeThrown < 0; } }
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * startingVelocity;
        damaging = false;
        animator = GetComponent<Animator>();
        animator.SetBool("Spin", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!armed)
        {
            timeThrown -= Time.deltaTime;
            if(armed)
            {
                rb.velocity = Vector3.zero;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                animator.SetBool("Spin", true);
                //Some other indicator of being armed besides stopping
            }
        }
        else
        {
            CheckForEnemy();
        }
    }

    void CheckForEnemy()
    {
        foreach (Collider2D obj in Physics2D.OverlapCircleAll(transform.position, radiusOfTrigger))
        {
            if (obj.tag == "Enemy")
            {
                GoOff();
            }
        }
    }


    void GoOff()
    {
        //TODO
        foreach (Collider2D obj in Physics2D.OverlapCircleAll(transform.position, radiusOfDamage))
        {
            if (obj.tag == "Enemy")
            {
                obj.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
        }
        damaging = true;
        animator.SetTrigger("Explode");
    }

    void End()
    {
        Destroy(this.gameObject);
    }
}
