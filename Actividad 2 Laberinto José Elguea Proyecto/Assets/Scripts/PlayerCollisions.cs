using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

    PlayerMovement playerMov; //Objeto del tipo PlayerMovement para acceder a sus metodos

    private void Start()
    {
        playerMov = GetComponent<PlayerMovement>(); //Obtiene acceso al script del mismo objeto
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Trap") 
        {
            playerMov.kill(); //llamada al metodo de respawn al tocar una trampa
        }

    }
}
