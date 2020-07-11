using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmineController : MonoBehaviour
{
    Rigidbody2D rb;
    public float radiusOfTrigger;
    public float startingVelocity;
    public float timeThrown;
    bool armed { get { return timeThrown < 0; } }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * startingVelocity;
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
        Debug.Log("Bomb Triggered By Enemy");
        Destroy(this.gameObject);
    }
}
