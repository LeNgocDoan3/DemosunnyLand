using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirX = 0f;
    public float moveSpeed;
    public float jumpForce;
    private enum MovementState {idle, run, jump, fall, duck, climp};
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimationState();
    }
   private void UpdateAnimationState()
   {
    MovementState state;
    if (dirX > 0f)
    {
        state = MovementState.run;
        sprite.flipX = false;
    }
    else if (dirX < 0f)
    {
        state = MovementState.run;
        sprite.flipX = true;
    }
    else
    {
        state  = MovementState.idle;
    }
    
    if(rb.velocity.y >1f)
    {
        state  = MovementState.jump;
    }
    else if ( rb.velocity.y <1f)
    {
        state = MovementState.fall;
    }
    anim.SetInteger("state", (int)state);
   }
}