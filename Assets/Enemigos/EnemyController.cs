using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform waypointCombate; // Waypoint para la nueva posici�n
    public Vector3 newScale; // Nuevo tama�o a aplicar

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnRaycastHit()
    {
        if (waypointCombate != null)
        {
            Debug.Log("Cambiando posici�n y tama�o del Enemigo");
            transform.position = waypointCombate.position;
            transform.localScale = newScale;
        }
        else
        {
            Debug.Log("waypoint es null");
        }
    }
}




/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
        {
            Destroy(gameObject);
        }
    }
}
*/