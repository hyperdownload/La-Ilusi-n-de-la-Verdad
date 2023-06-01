using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform spawnPoint;
    public int numberOfObjects = 5;
    public float generationInterval = 2f;
    public float detectionRadius = 5f;
    public LayerMask playerLayer;

    private bool playerInRange = false;
    private float generationTimer = 0f;
    private int generatedObjects = 0;

    void Update()
    {
        // Comprobar si el jugador está dentro del rango de detección
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer);
        playerInRange = (playerCollider != null);

        // Generar objetos si el jugador está en rango y aún no se han generado todos
        if (playerInRange && generatedObjects < numberOfObjects)
        {
            generationTimer += Time.deltaTime;

            if (generationTimer >= generationInterval)
            {
                GenerateObject();
                generationTimer = 0f;
            }
        }
    }

    void GenerateObject()
    {
        // Instanciar el prefab en el punto de generación
        Instantiate(objectPrefab, spawnPoint.position, spawnPoint.rotation);

        generatedObjects++;

        // Detener la generación si se han generado todos los objetos necesarios
        if (generatedObjects >= numberOfObjects)
        {
            enabled = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Dibujar un gizmo para visualizar el rango de detección
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}