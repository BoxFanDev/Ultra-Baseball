using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batter : MonoBehaviour
{
    public Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private float dirX;

    public float moveSpeed = 5f;
    public float jumpVelocity = 14f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float fastFallMultiplier = 3f;

    private enum MovementState
    {
        idle, running, jumping, falling
    }
        
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * jumpVelocity;

        }


        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        if (rb.velocity.y <= 0 && Input.GetButtonDown("Fire3"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fastFallMultiplier - 1) * Time.deltaTime;
        }

        if (Input.inputString != "") Debug.Log(Input.inputString);

        UpdateAnimationState();

    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            Debug.Log("running");
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }
}
