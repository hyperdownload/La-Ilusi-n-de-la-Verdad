using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private Rigidbody2D playerRb;
    private Vector2 moveInput;
    private float angle;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    void Update() {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY);
        if (Input.GetKeyDown(KeyCode.A)){
            angle = -180;
        }
        if (Input.GetKeyDown(KeyCode.D)){
            angle = 0;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
        Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        // Aplicar la rotación al transform del jugador
        transform.rotation = rotation;
    }
    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + moveInput * speed * Time.fixedDeltaTime);

    }
}

