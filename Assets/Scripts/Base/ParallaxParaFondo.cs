using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParallaxParaFondo : MonoBehaviour
{
    public RawImage capaSuperior;
    public GameObject jugador;
    float velocidadSup;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        velocidadSup = jugador.transform.position.y / speed;
        capaSuperior.uvRect = new Rect(capaSuperior.uvRect.x, velocidadSup, capaSuperior.uvRect.width, capaSuperior.uvRect.height);
    }
}
