using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Object : MonoBehaviour
{
    public Inventario inventario;
    // public float cantidadPuntos;
    // public Balas balas;

    // Start is called before the first frame update
    void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {

            Destroy(gameObject);

        }
    }
}
