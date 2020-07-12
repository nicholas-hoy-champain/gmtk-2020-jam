using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonicController : MonoBehaviour
{
    WizardController wizardController;
    public float manaPerSecondMultiplier = 3;
    Rigidbody2D rigidbody;
    Animator anim;
    public Vector3 closest;
    public GameObject demonAim;
    public List<GameObject> spawnableObject;
    public float timeBetweenAttacks;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        time = timeBetweenAttacks;
        wizardController = GetComponent<WizardController>();
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (wizardController.possessed)
            BeDemon();
    }

    void BeDemon()
    {
        //Significant Mana Buff
        wizardController.currentMana = Mathf.Min(wizardController.manaMax, wizardController.currentMana + (wizardController.manaRegenPerSecond * (manaPerSecondMultiplier - 1)));

        UpdateFacing();

        if (time > 0)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                Instantiate(spawnableObject[Random.Range(0, spawnableObject.Count)], demonAim.transform.position, demonAim.transform.rotation);
                time = timeBetweenAttacks;
            }
        }
    }


    private void FixedUpdate()
    {
        if (wizardController.possessed)
            BeDemonFixed();
    }

    void BeDemonFixed()
    {
        HeadToNearestEnemy();
    }

    void UpdateFacing()
    {
        if (rigidbody.velocity.normalized.x > 1.0f / (Mathf.Sqrt(2)))
            anim.SetInteger("Cardinal Direction", 0);
        else if (rigidbody.velocity.normalized.x < -1.0f / (Mathf.Sqrt(2)))
            anim.SetInteger("Cardinal Direction", 2);
        else if (rigidbody.velocity.normalized.y > 1.0f / (Mathf.Sqrt(2)))
            anim.SetInteger("Cardinal Direction", 1);
        else if (rigidbody.velocity.normalized.y < -1.0f / (Mathf.Sqrt(2)))
            anim.SetInteger("Cardinal Direction", 3);
    }

    void HeadToNearestEnemy()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            closest = GameObject.FindGameObjectsWithTag("Enemy")[0].transform.position;

            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                if (Vector3.Distance(obj.transform.position, transform.position) < Vector3.Distance(closest, transform.position))
                {
                    closest = obj.transform.position;
                }
            }

            demonAim.GetComponent<FacePosition>().LookAt2D(closest);

            if (Vector3.Distance(closest, transform.position) < 1.0f)
            {
                closest = transform.position;
            }
        }
        else
        {
            closest = transform.position;

            demonAim.GetComponent<FacePosition>().LookAt2D(new Vector3(Random.value - 0.5f, Random.value - 0.5f, 0) + closest);
        }


        rigidbody.velocity = (closest - transform.position).normalized * GetComponent<PlayerMovement>().baseSpeed;
    }
}
