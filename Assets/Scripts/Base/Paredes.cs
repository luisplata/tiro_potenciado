﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paredes : MonoBehaviour
{
    //las paredes siempre estaran a la altura del player
    public GameObject player;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector2(transform.position.x, player.transform.position.y);
    }
}
