using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KalaMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 6f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    private float defaultGravityScale; // To store the default gravity scale

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private Animator anim;
    
    void Start()
    {
        defaultGravityScale = rb.gravityScale; // Store the default gravity scale
        anim = GetComponent<Animator>();
        }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if ((Input.GetButtonUp("Jump") || Input.GetKeyUp(KeyCode.W)) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }


        anim.SetBool("run", horizontal !=0);
        anim.SetBool("grounded", IsGrounded());
    

        Flip();

        
        //check
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        // Check if the player is on a slope and not moving horizontally
        if (IsOnSlope() && Mathf.Approximately(horizontal, 0))
        {
            rb.gravityScale = 0; // Remove gravity effect to prevent sliding
        }
        else
        {
            rb.gravityScale = defaultGravityScale; // Reset to default gravity
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool IsOnSlope()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f, groundLayer);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("Slope"))
            {
                return true;
            }
        }
        return false;
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
