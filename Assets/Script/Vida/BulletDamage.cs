using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float damageAmount = 10f;

    void OnCollisionEnter(Collision collision)
    {
        // Destruye la bala cuando colisiona con cualquier cosa
        Destroy(gameObject);
    }
}
