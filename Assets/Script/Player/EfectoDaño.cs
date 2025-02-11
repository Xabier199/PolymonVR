using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DamageEffect : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    private Vignette vignette;
    private bool isDamaged;

    void Start()
    {
        postProcessVolume.profile.TryGetSettings(out vignette);
        vignette.active = false;  // Efecto desactivado inicialmente
    }

    void Update()
    {
        if (isDamaged)
        {
            vignette.active = true;
            // Podrías agregar un tiempo de enfriamiento para desactivar el efecto después de un tiempo
        }
        else
        {
            vignette.active = false;
        }
    }

    public void TakeDamage()
    {
        isDamaged = true;
        // Desactiva el daño después de un breve retraso
        Invoke("ResetDamage", 1.0f);  // Ajusta el tiempo según sea necesario
    }

    void ResetDamage()
    {
        isDamaged = false;
    }
}
