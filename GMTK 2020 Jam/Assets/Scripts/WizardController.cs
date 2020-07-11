using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite demonicSprite;

    public SpriteRenderer pointingIndicator;

    public float healthMax;
    public float health;
    public bool possessed;
    public bool busy;
    public float manaMax;
    public float currentMana;
    public float manaRegenPerSecond;
    public float corruptionLevel;
    public float corruptionBaseTime;
    public float timeCorrupted;
    public float normalBaseTime;
    public float timeNormal;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        currentMana = manaMax;
        health = healthMax;

        NormalInitiate();
    }

    // Update is called once per frame
    void Update()
    {
        RegenMana();
        animator.SetBool("Possessed", possessed);
        animator.SetBool("Moving", rb.velocity.magnitude > 0.1f);

        if (!possessed)
        {
            FlipSpriteToMouse();

            timeNormal -= Time.deltaTime;
            if(timeNormal <= 0)
            {
                CorruptInitiate();
            }
        }
        else
        {
            timeCorrupted -= Time.deltaTime;
            if(timeCorrupted <= 0)
            {
                NormalInitiate();
            }
        }
    }

    void RegenMana()
    {
        currentMana = Mathf.Min(manaMax, currentMana + manaRegenPerSecond * Time.deltaTime);
    }

    void FlipSpriteToMouse()
    {
        Vector2 pos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(pos);
        float angle = pointingIndicator.transform.parent.GetComponent<FacePosition>().AngleToFace2D(pos);

        if (angle >= 45 && angle < 135)
            animator.SetInteger("Cardinal Direction", 1);
        else if (angle >= 135 || angle < -135)
            animator.SetInteger("Cardinal Direction", 2);
        else if (angle >= -135 && angle < -45)
            animator.SetInteger("Cardinal Direction", 3);
        else
            animator.SetInteger("Cardinal Direction", 0);
    }

    void CorruptInitiate()
    {
        possessed = true;
        timeCorrupted = corruptionBaseTime * (1 + corruptionLevel);
        spriteRenderer.sprite = demonicSprite;
        pointingIndicator.enabled = false;
        rb.velocity = Vector2.zero;
    }

    void NormalInitiate()
    {
        possessed = false;
        timeNormal = normalBaseTime;
        spriteRenderer.sprite = normalSprite;
        pointingIndicator.enabled = true;
    }

    public void GainCorruption(DemonSoulController data)
    {
        health = Mathf.Min(healthMax, health + data.healthIncrease);
        currentMana = Mathf.Min(manaMax, currentMana + data.manaIncrease);
        corruptionLevel =+ data.corruptionIncrease;

        switch(data.powerGain)
        {
            case GainPowerPrompt.none:
                break;
            default:
                break;
        }
    }
}
