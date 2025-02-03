using UnityEngine;

public class Vendor : MonoBehaviour
{
    public GameObject shopWindow;  // La ventana de la tienda
    public float interactionRange = 3f;  // Rango para abrir la tienda
    private Transform player;  // Referencia al jugador

    void Start()
    {
        // Suponiendo que el jugador tiene la etiqueta "Player"
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Asegúrate de que la tienda esté cerrada al inicio
        if (shopWindow != null)
            shopWindow.SetActive(false);
    }

    void Update()
    {
        // Comprobamos la distancia entre el vendedor y el jugador
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= interactionRange)
        {
            // Si el jugador está cerca, mostramos la tienda
            if (!shopWindow.activeSelf)
            {
                shopWindow.SetActive(true);
            }
        }
        else
        {
            // Si el jugador se aleja, cerramos la tienda
            if (shopWindow.activeSelf)
            {
                shopWindow.SetActive(false);
            }
        }
    }
}