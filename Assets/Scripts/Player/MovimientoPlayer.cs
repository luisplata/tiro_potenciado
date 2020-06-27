using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    [SerializeField]
    private bool estaEnContactoConAlgo;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!estaEnContactoConAlgo)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0));
            //va a rotar el sprite
            //Debug.Log("Rotacion del Rigi " + GetComponent<Rigidbody2D>().rotation);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Colisiona con: " + collision.transform.name);
        if(collision.transform.name != "limites")
        {
            estaEnContactoConAlgo = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name != "limites")
        {
            estaEnContactoConAlgo = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.name != "limites")
        {
            estaEnContactoConAlgo = false;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.name != "limites")
        {
            estaEnContactoConAlgo = false;
        }
    }
}
