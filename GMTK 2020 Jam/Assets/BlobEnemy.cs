using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobEnemy : MonoBehaviour
{
    public float max;
    public float min;
    float time;
    GameObject target;
    public GameObject loogiePrefab;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindObjectOfType<WizardController>().gameObject;
        time = max * 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        float angle = GetComponent<FacePosition>().AngleToFace2D(target.transform.position);

        if (angle >= 45 && angle < 135)
            animator.SetInteger("Facing", 1);
        else if (angle >= 135 || angle < -135)
            animator.SetInteger("Facing", 2);
        else if (angle >= -135 && angle < -45)
            animator.SetInteger("Facing", 3);
        else
            animator.SetInteger("Facing", 0);
        
        if(time > 0)
        {
            time -= Time.deltaTime;
            if(time <= 0)
            {
                animator.SetTrigger("Attack");
            }
        }
    }

    void SpawnLoogie()
    {
        time = Random.Range(min, max);
        Instantiate(loogiePrefab, transform.position, Quaternion.Euler(0, 0, GetComponent<FacePosition>().AngleToFace2D(target.transform.position)));
    }
}
