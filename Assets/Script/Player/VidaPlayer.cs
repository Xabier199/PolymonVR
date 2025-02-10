using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    [SerializeField] private Slider healthSlider; // Referencia al slider de vida
    [SerializeField] private float maxHealth = 10f; // Vida máxima del jugador
    private float currentHealth; // Vida actual del jugador

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthSlider();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthSlider();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthSlider()
    {
        healthSlider.value = currentHealth;
    }

    private void Die()
    {
        // Lógica para cuando el jugador muere
        Debug.Log("Jugador muerto.");
    }
}

