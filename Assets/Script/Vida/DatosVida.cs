using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatosJugador : MonoBehaviour
{
    public int VidaPleyer;
    public Slider vidaVisual;
    private void Update()
    {
        vidaVisual.GetComponent<Slider>().value = VidaPleyer;
        if (VidaPleyer <= 0)
        {
            Debug.Log("Game over");
        }
    }
}
