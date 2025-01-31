using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public int maxHealth = 100;
    private int currentHealth;
    public GameObject objectToDestroy; // Objeto a destruir cuando la vida llega a cero
    public GameObject healthInterface; // Nuevo campo para controlar la visibilidad de la interfaz

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        healthInterface.SetActive(false); // Inicia invisible
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        healthSlider.value = currentHealth;

        if (currentHealth == 0 && objectToDestroy != null)
        {
            Debug.Log("Destruyendo el objeto: " + objectToDestroy.name); // Mensaje de depuración
            Destroy(objectToDestroy); // Destruye el objeto asignado
        }

        StartCoroutine(ShowHealthInterface()); // Muestra la interfaz de vida
    }

    private IEnumerator ShowHealthInterface()
    {
        healthInterface.SetActive(true); // Hacer visible
        yield return new WaitForSeconds(5f); // Esperar 5 segundos
        healthInterface.SetActive(false); // Hacer invisible
    }
}



/*using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public int maxHealth = 100;
    private int currentHealth;
    public GameObject objectToDestroy; // Nuevo campo para asignar el objeto a destruir

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Destroy(objectToDestroy); // Destruye el objeto asignado
        }
        healthSlider.value = currentHealth;
    }
}*/


