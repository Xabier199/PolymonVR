using UnityEngine;
using UnityEngine.UI; // Para usar Toggle

public class SkyboxPassthroughToggle : MonoBehaviour
{
    public Toggle passthroughToggle;         // Referencia al Toggle (Checkbox)
    public Material skyboxMaterial;         // Material del Skybox virtual
    private OVRPassthroughLayer passthroughLayer; // Componente Passthrough Layer
    private Camera mainCamera;              // C?mara principal

    void Start()
    {
        // Obtener la c?mara principal
        mainCamera = Camera.main;

        // Obtener el componente OVR Passthrough Layer
        passthroughLayer = mainCamera.GetComponent<OVRPassthroughLayer>();
        if (passthroughLayer == null)
        {
            Debug.LogError("OVRPassthroughLayer no encontrado en la c?mara principal.");
            return;
        }

        // Configurar el estado inicial seg?n el Toggle
        UpdateView(passthroughToggle.isOn);

        // Asignar el m?todo para que se ejecute cuando cambie el estado del Toggle
        passthroughToggle.onValueChanged.AddListener(UpdateView);
    }

    // M?todo para alternar entre Skybox y Passthrough
    public void UpdateView(bool isPassthroughActive)
    {
        if (isPassthroughActive)
        {
            // Activar Passthrough (c?mara real)
            passthroughLayer.enabled = true;
            RenderSettings.skybox = null; // Deshabilitar el Skybox
            mainCamera.clearFlags = CameraClearFlags.SolidColor;
        }
        else
        {
            // Activar Skybox (virtual)
            passthroughLayer.enabled = false;
            RenderSettings.skybox = skyboxMaterial; // Establecer el Skybox virtual
            mainCamera.clearFlags = CameraClearFlags.Skybox;
        }
    }
}
