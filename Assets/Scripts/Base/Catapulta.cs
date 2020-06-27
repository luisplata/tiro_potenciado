using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapulta : MonoBehaviour
{
    //tenemos que usar los dos botones al mismo tiempo para impulsar al jugador
    [SerializeField]
    private int estadoDeCatapulta;//los estados son: 0:reposo, 1:impulsando, 2:lanzando. Al finalizar el lanzamiento queda en reposo
    public Rigidbody2D player;
    public float speed;
    private bool playerEstaEnPlataforma;
    // Update is called once per frame
    void Update()
    {
        if (playerEstaEnPlataforma){
            //Debug.Log("Input.GetKey(KeyCode.LeftArrow) " + Input.GetKey(KeyCode.LeftArrow) + " -  Input.GetKey(KeyCode.RightArrow) " + Input.GetKey(KeyCode.RightArrow));
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
            {
                GetComponent<Animator>().SetTrigger("impulsar");
                estadoDeCatapulta = 1;
            }
            else
            {
                if(estadoDeCatapulta == 1)
                {
                    GetComponent<Animator>().SetTrigger("soltar");
                    estadoDeCatapulta = 0;
                }
            }
        }
    }

    public void AddForceToPlayer()
    {
        Debug.Log("Se añadio la fuerza de " + (Vector2.up * speed));
        player.AddForce(Vector2.up * speed);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            playerEstaEnPlataforma = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            playerEstaEnPlataforma = false;
        }
    }
}
