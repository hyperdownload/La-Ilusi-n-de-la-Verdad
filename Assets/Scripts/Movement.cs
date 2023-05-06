using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask groundLayerMask;

    private Rigidbody2D rb;
    private bool isGrounded = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Get input
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        bool jumpInput = Input.GetButtonDown("Jump");

        // Move player horizontally
        Vector2 velocity = rb.velocity;
        velocity.x = horizontalInput * speed;
        rb.velocity = velocity;

        // Flip player sprite based on movement direction
        if (horizontalInput != 0)
        {
            transform.localScale = new Vector3(horizontalInput > 0 ? 1 : -1, 1, 1);
        }

        // Check if player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, groundLayerMask);

        // Jump if grounded and jump button is pressed
        if (isGrounded && jumpInput)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
}

