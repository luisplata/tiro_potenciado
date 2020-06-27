using UnityEngine;
using System.Collections;

public class CanionRojo : CanionGenerico
{
    private void Start()
    {
        color = "Amarillo";
        tiempoDeEspera = 1 / 2;
        fuerza = 1.5f;
    }
}
