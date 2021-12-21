using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private enum MovenmentState {idel, jumping, falling, running}

    public static Rigidbody2D rb;
    private BoxCollider2D box;
    public static Animator anim;
    private SpriteRenderer spr;
    private float dirx;
    [SerializeField] private float movespeed = 10f;
    [SerializeField] private float jumpforce = 14f;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private AudioSource Jump;
   // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("HI this is Code Craft");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
         
        dirx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirx*movespeed,rb.velocity.y);

        if (Input.GetButton("Jump")&& isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            Jump.Play();
        }
        UpdateAnimation();

    }
    private void UpdateAnimation()
    {
        MovenmentState state;
        if(dirx == 0)
        {
            state = MovenmentState.idel;
        }
        if (dirx > 0)
        {
            state = MovenmentState.running;
            spr.flipX = false;
        }
        else if (dirx < 0)
        {
            state = MovenmentState.running;
            spr.flipX=true;
        }
        else
        {
            state = MovenmentState.idel;
        }
        if (rb.velocity.y>.1f)
        {
            state = MovenmentState.jumping;
        }
        else if (rb.velocity.y<-.1f)
        {
            state = MovenmentState.falling;
        }
        anim.SetInteger("state",(int)state);
    }
    private bool isGrounded()
    {
        return Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, .1f, Ground);
    }
}
