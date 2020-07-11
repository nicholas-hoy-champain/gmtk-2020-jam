using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float baseSpeed = 5;
    public float speedMultiplier = 1;

    Vector2 move;

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
    }

    void CheckInput()
    {
        move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    }

    private void FixedUpdate()
    {
        if (!wc.possessed)
            rb.velocity = move * baseSpeed * speedMultiplier;
        else
        {
            if (rb.velocity.x > 0)
                spriteRenderer.flipX = false;
            else if (rb.velocity.x < 0)
                spriteRenderer.flipX = true;
        }
    }
}
