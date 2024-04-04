using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KalaMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 6f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    private float jumpCD = 0f;
    private float jumpLastTime = 0f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal" );

        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W))   && IsGrounded() && (jumpLastTime>=jumpCD)) 
        {
            // Debug.Log("Jump Detected");
            jumpLastTime = 0f;
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        // if(!IsGrounded()){
        //     Debug.Log("In Air");
        // }

        if ((Input.GetButtonUp("Jump") || Input.GetKeyUp(KeyCode.W))&& rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            
        }
        
        if(IsGrounded()){
            jumpLastTime+=Time.deltaTime;
        }

        

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    

    private bool IsGrounded()
    {   
        // Debug.Log("isgroundcheck");
        // Debug.Log(groundCheck.position);
        // Debug.Log(groundLayer);
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            // Debug.Log("Move Detected");
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}