using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // Prefab de la bala
    [SerializeField] private Transform bulletSpawnPoint; // Punto de spawn de la bala
    [SerializeField] private float shootingInterval = 2f; // Intervalo de tiempo entre disparos
    [SerializeField] private float shootingRange = 15f; // Rango de distancia para disparar al jugador
    [SerializeField] private float bulletSpeed = 10f; // Velocidad de la bala
    private Transform player; // Referencia al jugador

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("TryShootPlayer", shootingInterval, shootingInterval);
    }

    private void TryShootPlayer()
    {
        if (Vector3.Distance(transform.position, player.position) <= shootingRange)
        {
            ShootAtPlayer();
        }
    }

    private void ShootAtPlayer()
    {
        Vector3 direction = (player.position - bulletSpawnPoint.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().linearVelocity = direction * bulletSpeed;
    }
}
