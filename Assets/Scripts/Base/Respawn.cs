using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject player, canionRojo, canionAmarillo, canionVerde, basePlataforma;
    public float[] posicionesX = new float[] { -6, -3, 0, 3, 6 };
    private void Start()
    {
        basePlataforma = new GameObject();
        basePlataforma.transform.position = Vector3.zero;
        
        Collider2D[] listaDeColisiones = Physics2D.OverlapBoxAll(basePlataforma.transform.position, Vector2.one, 0);
        if(listaDeColisiones.Length <= 0)
        {
            //spaneamos los cosos
            Instantiate(canionAmarillo).transform.position = new Vector2(posicionesX[0], basePlataforma.transform.position.y);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
