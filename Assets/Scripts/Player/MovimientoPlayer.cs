using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    public bool estaEnContactoConAlgo, finDelJuego;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (finDelJuego)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return;
        }
        if (!estaEnContactoConAlgo)
        {
            GetComponent<Rigidbody2D>().AddForce(ParaMoverElJugador(Input.GetAxis("Horizontal"), Time.deltaTime));
        }
    }

    public Vector2 ParaMoverElJugador(float input, float deltaTime)
    {
        return new Vector2(input * deltaTime * speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ColisionConCosas(collision.transform.name);
    }

    public void ColisionConCosas(string nombre)
    {
        if (nombre != "limites")
        {
            estaEnContactoConAlgo = true;
        }
    }

    public void SalioDeLaColisionConCosas(string nombre)
    {
        if (nombre != "limites")
        {
            estaEnContactoConAlgo = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ColisionConCosas(collision.transform.name);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        SalioDeLaColisionConCosas(collision.transform.name);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SalioDeLaColisionConCosas(collision.transform.name);
    }
}
