using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float bulletdamage = 1f; // Daño que inflige la bala

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            VidaPlayer playerHealth = other.GetComponent<VidaPlayer>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(bulletdamage);
            }
            Destroy(gameObject);
        }
    }
}
