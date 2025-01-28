using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrullarYSeguir : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Transform[] puntosMovimiento;
    [SerializeField] private float distanciaMinima;
    [SerializeField] private float distanciaPersecucion; // Distancia para empezar a seguir al jugador
    [SerializeField] private float distanciaSeguridad; // Distancia mínima para mantener con el jugador
    [SerializeField] private float velocidadRotacion;
    private int numeroAleatorio;
    private SpriteRenderer spriteRenderer;
    private Transform jugador; // Referencia al jugador
    private bool persiguiendoJugador = false;

    private void Start()
    {
        numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        jugador = GameObject.FindGameObjectWithTag("Player").transform; // Asume que el jugador tiene el tag "Player"
    }

    private void Update()
    {
        float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);
        if (distanciaAlJugador < distanciaPersecucion)
        {
            persiguiendoJugador = true;
        }
        else if (distanciaAlJugador > distanciaPersecucion)
        {
            persiguiendoJugador = false;
        }

        if (persiguiendoJugador)
        {
            // Seguir al jugador manteniendo una distancia segura
            SeguirJugador();
        }
        else
        {
            // Patrullar entre waypoints
            PatrullarWaypoints();
        }
    }

    private void SeguirJugador()
    {
        float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);
        if (distanciaAlJugador > distanciaSeguridad)
        {
            // Seguir al jugador si la distancia es mayor que la distancia de seguridad
            transform.position = Vector3.MoveTowards(transform.position, jugador.position, velocidadMovimiento * Time.deltaTime);

            Vector3 direccion = (jugador.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direccion.x, 0, direccion.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * velocidadRotacion);
        }
        else
        {
            // Mantener la rotación mirando al jugador
            Vector3 direccion = (jugador.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direccion.x, 0, direccion.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * velocidadRotacion);
        }
    }

    private void PatrullarWaypoints()
    {
        transform.position = Vector3.MoveTowards(transform.position, puntosMovimiento[numeroAleatorio].position, velocidadMovimiento * Time.deltaTime);

        Vector3 direccion = (puntosMovimiento[numeroAleatorio].position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direccion.x, 0, direccion.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * velocidadRotacion);

        if (Vector3.Distance(transform.position, puntosMovimiento[numeroAleatorio].position) < distanciaMinima)
        {
            numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
        }
    }
}


