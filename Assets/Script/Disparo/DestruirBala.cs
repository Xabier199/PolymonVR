using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLifetime : MonoBehaviour
{
    [SerializeField] private float lifetime = 3f; // Tiempo de vida de la bala en segundos

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
