using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public RectTransform healthBar; // Asume que esta es una UI RectTransform

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        UpdateHealthBar();

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        float healthPercentage = currentHealth / maxHealth;
        healthBar.localScale = new Vector3(healthPercentage, 1f, 1f);
    }

    void Die()
    {
        // Aquí puedes añadir lo que quieras que pase cuando el enemigo muera
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Asume que el daño de la bala es un valor en un componente llamado BulletDamage
            float damage = collision.gameObject.GetComponent<BulletDamage>().damageAmount;
            TakeDamage(damage);
        }
    }
}

