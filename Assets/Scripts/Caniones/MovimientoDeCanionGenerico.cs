using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDeCanionGenerico : MonoBehaviour
{
    public bool alCentro, evaluado;
    public GameObject player;
    public CanionGenerico comportamientoCanion;
    public Vector2 direccionDeDisparo;
    public float speed, speedRotacion,movimiento;
    // Start is called before the first frame update
    void Start()
    {
        comportamientoCanion = GetComponent<CanionGenerico>();
        evaluado = true;
        speed = 500;
        speedRotacion = 2;
        //ahora una rotacion random
        float random = Random.Range(0, 360);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z +random);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 heading = transform.Find("direccion").transform.position - transform.position;
        float distancia = heading.magnitude;
        direccionDeDisparo = heading / distancia;
        if (alCentro)
        {
            player.GetComponent<Rigidbody2D>().velocity = transform.position - player.transform.position;
            if(Input.GetAxis("Horizontal") != 0)
            {
                movimiento = Input.GetAxis("Horizontal") * speedRotacion;
            }
            else
            {
                movimiento = 0;
            }
            movimiento *= -1;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + movimiento);
        }
        if (!evaluado)
        {
            GetComponent<Animator>().SetTrigger("Disparar");
            StartCoroutine(LanzarPlayer());
            evaluado = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //lo mandamos al centro del objeto?
            player = collision.gameObject;
            alCentro = true;
            evaluado = false;
        }
    }

    IEnumerator LanzarPlayer()
    {
        yield return new WaitForSeconds(comportamientoCanion.tiempoDeEspera);
        evaluado = true;
        alCentro = false;
        player.GetComponent<Rigidbody2D>().AddForce(direccionDeDisparo * comportamientoCanion.fuerza * speed);
        player = null;
        GetComponent<Animator>().SetTrigger("Disparo");
    }

    public void CambiarLaRotacionDeCoso()
    {
        float random = Random.Range(0, 360);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + random);
        GetComponent<Animator>().SetTrigger("CambioDeLado");
    }

}
