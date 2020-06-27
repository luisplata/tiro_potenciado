using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject canionRojo, canionAmarillo, canionVerde;
    public GameObject[] listaDeCaniones;
    private Vector2[] posicionesDeCaniones = new Vector2[] { 
        new Vector2(5,6f), 
        new Vector2(0, 6f), 
        new Vector2(-5, 6f), 
        new Vector2(5f, 1), 
        new Vector2(0, 1), 
        new Vector2(-5f, 1), 
        new Vector2(5f, -2.5f), 
        new Vector2(0, -2.5f), 
        new Vector2(-5f, -2.5f), 
        new Vector2(-5f, -2.5f), 
        new Vector2(5f, -6), 
        new Vector2(0, -6), 
        new Vector2(-5f, -6)
    };
    public float intervalosDe = 1.5f;
    public float radio;
    private void Start()
    {
        listaDeCaniones = new GameObject[] { canionRojo, canionAmarillo, canionVerde };
    }
    // Update is called once per frame
    void Update()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radio);
        bool hayCaniones = false;
        foreach(Collider2D c in hits)
        {
            if (c.transform.CompareTag("Canion"))
            {
                hayCaniones = true;
                break;
            }
        }
        if (!hayCaniones)
        {
            //Contenedor
            GameObject contenedor = new GameObject();
            Instantiate(contenedor);
            contenedor.transform.position = transform.position;
            contenedor.tag = "Canion";
            //Creo canionen en este punto
            foreach (Vector2 posicion in posicionesDeCaniones)
            {
                GameObject canion = Instantiate(listaDeCaniones[Random.Range(0, listaDeCaniones.Length)], contenedor.transform);
                canion.transform.position = new Vector2(contenedor.transform.position.x+posicion.x, contenedor.transform.position.y + posicion.y);
                canion.tag = "Canion";
            }
        }
        //Debug.Log("hits " + hits.Length + " - hayCaniones " + hayCaniones +" en: "+transform.name);
    }

}
