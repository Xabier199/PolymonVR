using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colisi�n detectada con: " + other.gameObject.name); // Mensaje de depuraci�n
        HealthBar healthBar = other.GetComponent<HealthBar>();
        if (healthBar != null)
        {
            healthBar.TakeDamage(damage);
            Destroy(gameObject); // Destruye la bala despu�s de la colisi�n
        }
    }
}
