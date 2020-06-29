using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Reloj : MonoBehaviour
{
    private int min, seg, mil;
    private float tiempo, tiempoMostrar;
    public int tiempoEnSegundos;
    public TextMeshProUGUI tiempo_ui;
    public PlayableDirector director;
    // Start is called before the first frame update
    void Start()
    {
        min = (int)tiempoEnSegundos / 60;
        seg = tiempoEnSegundos % 60;
        mil = 60;
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        tiempoMostrar = tiempoEnSegundos - tiempo;
        //Debug.Log("(tiempoMostrar - tiempoMostrar) " + (tiempoMostrar - (int)tiempoMostrar));
        min = (int)(tiempoMostrar / 60);
        seg = (int)(tiempoMostrar % 60);
        mil = (int)((tiempoMostrar - (int)tiempoMostrar) * 1000);
        //Debug.Log("Tiempo Restante: " + min + ":" + seg + ":" + mil);
        tiempo_ui.text = string.Format("{0}:{1}:{2}", min, seg, mil);
        if(min <= 0 && seg <= 0 && mil <= 0)
        {
            director.Play();
            StartCoroutine(GameOver());
        }
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("GameOver");
    }
}
