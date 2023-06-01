using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public Image Life;
    public float currentHealth;
    public float MaxLife;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Life.fillAmount=currentHealth/MaxLife;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Aquí puedes implementar la lógica de la muerte del jugador
        Debug.Log("El jugador ha muerto");
        // Por ejemplo, puedes mostrar un mensaje de game over, reiniciar el nivel, etc.
    }
}
