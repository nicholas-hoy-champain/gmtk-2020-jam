using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MeleeEnemy : MonoBehaviour
{
    public float attackRange;
    public float attackDelay;
    public GameObject hitBox1;
    public GameObject hitBox2;
    public GameObject hitBox3;
    public float time;
    public AIPath aIPath;

    Rigidbody2D rb;
    Animator anim;
    AIDestinationSetter aIDestinationSetter;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        aIDestinationSetter = GetComponent<AIDestinationSetter>();
        aIDestinationSetter.target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        SetDirection();
        if(time > 0)
        {
            time -= Time.deltaTime;
        }
        else if(Vector3.Distance(GameObject.FindWithTag("Player").transform.position,transform.position) <= attackRange)
        {
            anim.SetTrigger("Attack");
        }
    }

    void SetDirection()
    {
        if (aIPath.desiredVelocity.normalized.x > 1.0f / (Mathf.Sqrt(2)))
            anim.SetInteger("Facing", 0);
        else if (aIPath.desiredVelocity.normalized.x < -1.0f / (Mathf.Sqrt(2)))
            anim.SetInteger("Facing", 2);
        else if (aIPath.desiredVelocity.normalized.y > 1.0f / (Mathf.Sqrt(2)))
            anim.SetInteger("Facing", 1);
        else if (aIPath.desiredVelocity.normalized.y < -1.0f / (Mathf.Sqrt(2)))
            anim.SetInteger("Facing", 3);
    }

    void EndAttack()
    {
        time = attackDelay;
    }

    void spawnHitBox1()
    {
        Instantiate(hitBox1,transform).GetComponent<EnemyHitBox>().orgin = transform;
    }

    void spawnHitBox2()
    {
        Instantiate(hitBox2);
    }

    void spawnHitBox3()
    {
        Instantiate(hitBox3);
    }
}
