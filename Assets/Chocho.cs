using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAndActivate : MonoBehaviour
{
    public GameObject target; // El objeto que se va a desactivar y luego activar
    public float delay = 5.0f; // El tiempo en segundos antes de activar el objeto nuevamente

    void Start()
    {
        if (target != null)
        {
            // Desactivar el objeto
            target.SetActive(false);

            // Iniciar la corrutina para activarlo después del delay
            StartCoroutine(ActivateAfterDelay());
        }
    }

    IEnumerator ActivateAfterDelay()
    {
        // Esperar el tiempo especificado
        yield return new WaitForSeconds(delay);

        // Activar el objeto
        target.SetActive(true);
    }
}

