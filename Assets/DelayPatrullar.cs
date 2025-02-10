using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DelayPatrullar : MonoBehaviour
{
    [SerializeField] private MonoBehaviour scriptToActivate; // El script a activar
    [SerializeField] private float delay = 6f; // Retraso en segundos

    private void Start()
    {
        StartCoroutine(ActivateScriptAfterDelay());
    }

    private IEnumerator ActivateScriptAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        scriptToActivate.enabled = true;
    }
}
