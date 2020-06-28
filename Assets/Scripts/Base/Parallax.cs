using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    GameObject fondo1, fondo2, fondo3, aux;
    public GameObject camara, jugador;
    public float parallaxEfect;
    // Start is called before the first frame update
    void Start()
    {
        fondo1 = transform.Find("fondo1").gameObject;
        fondo2 = transform.Find("fondo2").gameObject;
        fondo3 = transform.Find("fondo3").gameObject;
    }
    private void FixedUpdate()
    {
        float distancia = (camara.transform.position.y * parallaxEfect);
        //Debug.Log("fondo3.transform.position.y " + fondo3.transform.localPosition.y+" fondo3.transform.position.y + (6.4f * 3) " + (fondo3.transform.localPosition.y + (6.4f * 3)));
        if (distancia - fondo2.transform.position.y >= 3)
        {
            fondo3.transform.localPosition = new Vector2(fondo3.transform.localPosition.x, fondo3.transform.localPosition.y + (6.4f * 3));
            aux = fondo2;
            fondo2 = fondo1;
            fondo1 = fondo3;
            fondo3 = aux;
        }
        if (distancia - fondo2.transform.position.y <= -3)
        {
            fondo1.transform.localPosition = new Vector2(fondo1.transform.localPosition.x, fondo1.transform.localPosition.y - (6.4f * 3));
            aux = fondo1;
            fondo1 = fondo2;
            fondo2 = fondo3;
            fondo3 = aux;
        }
    }
}
