#region 'Using' information
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion

// Using this tutorial: https://youtu.be/GChUpPnOSkg

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator anim;
    BoxCollider2D coll;

    [SerializeField] LayerMask jumpableGround;

    float dirX = 0f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 12f;

    enum MovementState { idle, running, jumping, falling }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal"); // 'getaxisraw' makes the player stop moving immediately when they release the key
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y); // controls right 'n' left movement

        if(Input.GetButtonDown("Jump") && IsGrounded()) // prevents holding space to fly off
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MovementState state;

        if (dirX > 0f) // if the player's moving right
        {
            state = MovementState.running; // they're running
            sprite.flipX = false; // and facing right
        }
        else if (dirX < 0f) // if the player's moving left
        {
            state = MovementState.running; // they're running
            sprite.flipX = true; // and facing left
        }
        else
        {
            state = MovementState.idle; // they're idling
        }

        if(rb.velocity.y > 0.1f) // if the player's jumping
        {
            state = MovementState.jumping;
        }
        else if ( rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("State", (int)state); // enums are ints, so this lets the code know to translate 'jumping', 'falling' etc to numbers
    }

    private bool IsGrounded() // checks for the player being on the ground before letting them jump. stops infinite jumps, basically.
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}