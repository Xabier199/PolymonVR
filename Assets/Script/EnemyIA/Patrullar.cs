using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrullar : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Transform[] puntosMovimiento;
    [SerializeField] private float distanciaMinima;
    [SerializeField] private float velocidadRotacion; // A�adimos una velocidad de rotaci�n
    private int numeroAleatorio;
    private SpriteRenderer SpriteRenderer;

    private void Start()
    {
        numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Movimiento hacia el punto
        transform.position = Vector3.MoveTowards(transform.position, puntosMovimiento[numeroAleatorio].position, velocidadMovimiento * Time.deltaTime);

        // Rotaci�n hacia el punto solo en el eje Y
        Vector3 direccion = (puntosMovimiento[numeroAleatorio].position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direccion.x, 0, direccion.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * velocidadRotacion);

        if (Vector3.Distance(transform.position, puntosMovimiento[numeroAleatorio].position) < distanciaMinima)
        {
            numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
        }
    }
}



/*private void girar()
   {
       if (transform.position.x < puntosMovimiento[numeroAleatorio].position.x)
       {
           SpriteRenderer.flipX = true;
       }
       else
       {
           SpriteRenderer.flipX = false;
       }
   }*/