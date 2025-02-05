using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObjectXZ : MonoBehaviour
{
    public Transform target; // El objeto al que se desea seguir

    void Update()
    {
        if (target != null)
        {
            // Obtener la posici�n actual del objeto
            Vector3 newPosition = transform.position;

            // Actualizar la posici�n X y Z seg�n el objeto objetivo
            newPosition.x = target.position.x;
            newPosition.z = target.position.z;

            // Aplicar la nueva posici�n
            transform.position = newPosition;
        }
    }
}
