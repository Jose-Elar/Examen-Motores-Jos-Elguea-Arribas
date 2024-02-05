using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger1 : MonoBehaviour
{
    public Rigidbody Objetotrampa;
    // Aqu� lo que hacemos es simplemente que si el trigger detecta al jugador, que tiene el tag Player, desactiva la opci�n isKinematic del Rigibody
    // para que se active las f�sicas, en este caso la gravedad y el objeto caiga, en el inspector indicamos que objeto es en el campo Objetotrampa
    //lo hemos puesto como public para que podamos gestionarlo desde el inspector
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Objetotrampa.isKinematic = false;
        }
    }
}
