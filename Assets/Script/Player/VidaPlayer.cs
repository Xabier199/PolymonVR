using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VidaPlayer : MonoBehaviour
{
    [SerializeField] private Slider healthSlider; // Referencia al slider de vida
    [SerializeField] private float maxHealth = 10f; // Vida m�xima del jugador
    private float currentHealth; // Vida actual del jugador

    [SerializeField] private GameObject damagePanel; // Referencia al panel de da�o
    [SerializeField] private RawImage deathImage; // Referencia a la Raw Image
    [SerializeField] private MonoBehaviour ovrPlayerController; // Referencia al script OVR Player Controller

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthSlider();
        damagePanel.SetActive(false); // Asegurarse de que el panel est� desactivado inicialmente
        deathImage.gameObject.SetActive(false); // Asegurarse de que la Raw Image est� desactivada inicialmente
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthSlider();

        // Activar el panel de da�o al recibir da�o
        damagePanel.SetActive(true);
        Invoke("HideDamagePanel", 1.0f); // Ajusta el tiempo seg�n sea necesario

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthSlider()
    {
        healthSlider.value = currentHealth;
    }

    private void Die()
    {
        // L�gica para cuando el jugador muere
        Debug.Log("Jugador muerto.");
        deathImage.gameObject.SetActive(true);
        if (ovrPlayerController != null)
        {
            ovrPlayerController.enabled = false; // Desactivar el script OVR Player Controller
        }
        Invoke("ReloadScene", 5.0f); // Recargar la escena despu�s de 5 segundos
    }

    private void HideDamagePanel()
    {
        damagePanel.SetActive(false);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}



/*using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    [SerializeField] private Slider healthSlider; // Referencia al slider de vida
    [SerializeField] private float maxHealth = 10f; // Vida m�xima del jugador
    private float currentHealth; // Vida actual del jugador

    [SerializeField] private GameObject damagePanel; // Referencia al panel de da�o

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthSlider();
        damagePanel.SetActive(false); // Asegurarse de que el panel est� desactivado inicialmente
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthSlider();

        // Activar el panel de da�o al recibir da�o
        damagePanel.SetActive(true);
        Invoke("HideDamagePanel", 1.0f); // Ajusta el tiempo seg�n sea necesario

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthSlider()
    {
        healthSlider.value = currentHealth;
    }

    private void Die()
    {
        // L�gica para cuando el jugador muere
        Debug.Log("Jugador muerto.");
    }

    private void HideDamagePanel()
    {
        damagePanel.SetActive(false);
    }
}*/


