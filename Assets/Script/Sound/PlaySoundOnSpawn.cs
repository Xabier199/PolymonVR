using UnityEngine;

public class PlaySoundOnSpawn : MonoBehaviour
{
    private AudioSource audioSource;

    void Awake()
    {
        // Obt�n el componente AudioSource del prefab
        audioSource = GetComponent<AudioSource>();

        // Reproduce el sonido
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
