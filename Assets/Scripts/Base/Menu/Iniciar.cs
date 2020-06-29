using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Iniciar : MonoBehaviour
{
    public TextMeshProUGUI mensaje;
    private void Start()
    {
        PlayerPrefs.SetInt("Score",0);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            mensaje.text = "Cargando...";
            SceneManager.LoadScene("Game");

        }
    }
}
