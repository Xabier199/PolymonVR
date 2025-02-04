using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMovement : MonoBehaviour
{
    private Vector3 initialPosition;

    void Start()
    {
        // Guardar la posición inicial del objeto
        initialPosition = transform.position;
    }

    void Update()
    {
        // Mantener la posición inicial para bloquear el movimiento
        transform.position = initialPosition;
    }
}
