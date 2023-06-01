using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    //Life
    public Image Life;
    public float currentHealth = 100;
    public float MaxLife = 100;

    // Movement variables
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    // Sound variables
    public AudioClip[] footstepSounds;
    public float footstepInterval = 0.5f;

    private int angle;
    private bool isJumping = false;
    private bool isGrounded = false;
    private Rigidbody2D rb;
    private AudioSource audioSource;
    private float footstepTimer = 0f;
    public static bool IsAlive;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        IsAlive = true;
    }

    void Update()
    {
        if (IsAlive)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            // Check if the character is on the ground
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

            // Horizontal movement
            rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);

            // Jump if the character is on the ground and the jump key is pressed
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }

            // Play footsteps sound if the character is on the ground and moving
            if (isGrounded && Mathf.Abs(moveHorizontal) > 0f)
            {
                footstepTimer += Time.deltaTime;
                if (footstepTimer >= footstepInterval)
                {
                    footstepTimer = 0f;
                    PlayRandomFootstepSound();
                }
            }

            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("Menu");
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.P))
            {
                SceneManager.LoadScene("Game");
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Life.fillAmount = currentHealth / MaxLife;
        if (currentHealth <= 0)
        {
            IsAlive = false;
        }
    }

    private void PlayRandomFootstepSound()
    {
        if (footstepSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, footstepSounds.Length);
            audioSource.clip = footstepSounds[randomIndex];
            audioSource.Play();
        }
    }
}

