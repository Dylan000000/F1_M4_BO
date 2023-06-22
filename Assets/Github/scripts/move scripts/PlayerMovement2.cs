using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design.Serialization;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    private float horizontal;
    public float speed = 5f;
    public float jumpingPower = 10f;
    private bool isFacingRight = true;
    public Animator animator;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity= new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            
        }
        

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            
        }
       

        if (Input.GetButton("Horizontal"))
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        Turn();
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void fixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Turn()
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
