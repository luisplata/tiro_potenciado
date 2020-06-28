using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puntuacion : MonoBehaviour
{
    public GameObject player, base_plataforma;
    public TextMeshProUGUI max, actual;
    private int max_int, actual_int;
    // Start is called before the first frame update
    void Start()
    {
        max_int = 0;
        actual_int = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //la puntuacuion actual es la distancia del player desde la base
        actual_int =  (int)(player.transform.position.y - base_plataforma.transform.position.y);
        //Debug.Log("Distancia desde la base: "+ actual_int);
        if(actual_int > max_int)
        {
            max_int = actual_int;
        }

        actual.text = actual_int.ToString();
        max.text = max_int.ToString();
    }
}
