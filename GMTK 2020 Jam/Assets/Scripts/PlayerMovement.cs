using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float baseSpeed = 5;
    public float speedMultiplier = 1;

    public Vector2 move;

    Rigidbody2D rb;
    WizardController wc;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        wc = GetComponent<WizardController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        if (!wc.possessed && !wc.normalShielding)
            rb.velocity = move * baseSpeed * speedMultiplier;
        else
        {
            if (rb.velocity.x > 0)
                spriteRenderer.flipX = false;
            else if (rb.velocity.x < 0)
                spriteRenderer.flipX = true;
        }

        if (wc.normalShielding)
        {
            rb.velocity = Vector2.zero;
        }
    }

    void CheckInput()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if (move == Vector2.zero)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (!wc.possessed && !wc.normalShielding)
            rb.velocity = move * baseSpeed * speedMultiplier;
        else
        {
            if (rb.velocity.x > 0)
                spriteRenderer.flipX = false;
            else if (rb.velocity.x < 0)
                spriteRenderer.flipX = true;
        }

        if (wc.normalShielding)
        {
            rb.velocity = Vector2.zero;
        }
    }
}