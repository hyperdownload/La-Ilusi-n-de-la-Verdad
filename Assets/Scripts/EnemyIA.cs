using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float visionRange = 5f;
    public float attackRange = 1f;
    public float attackCooldown = 2f;
    public int damage = 10;
    public LayerMask obstacleLayer;
    public Transform groundCheck;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isAttacking;
    private float attackTimer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Comprobar si el jugador está en el rango de visión
        bool playerVisible = CanSeePlayer();

        if (playerVisible)
        {
            // Calcular la dirección hacia el jugador
            Vector2 direction = (player.position - transform.position).normalized;

            // Moverse hacia el jugador
            rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);

            // Comprobar si el jugador está dentro del rango de ataque
            if (Vector2.Distance(transform.position, player.position) <= attackRange && !isAttacking && attackTimer <= 0f)
            {
                Attack();
                attackTimer = attackCooldown;
            }
        }
        else
        {
            // Detener el movimiento si el jugador no es visible
            rb.velocity = Vector2.zero;
        }

        // Actualizar el temporizador de ataque
        if (attackTimer > 0f)
        {
            attackTimer -= Time.deltaTime;
        }
    }

    private bool CanSeePlayer()
    {
        // Comprobar si el jugador está dentro del rango de visión
        if (Vector2.Distance(transform.position, player.position) <= visionRange)
        {
            // Comprobar si hay obstáculos entre el enemigo y el jugador
            RaycastHit2D hit = Physics2D.Linecast(transform.position, player.position, obstacleLayer);

            if (hit.collider == null)
            {
                // No hay obstáculos, el jugador es visible
                return true;
            }
        }

        // El jugador no es visible
        return false;
    }

    private void Attack()
    {
        // Aquí puedes implementar la lógica de ataque
        Debug.Log("El enemigo ataca al jugador");
        // Resta vida al jugador
        player.GetComponent<PlayerHealth>().TakeDamage(damage);
    }

    public void OnDrawGizmos()
    {
        // Dibuja una línea roja entre el enemigo y el jugador
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, player.position);

        // Dibuja un círculo para el rango de ataque
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
