using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntos_Moneda : MonoBehaviour
{
    public GameObject ObjPuntos;
    public int cantidadPuntos;
    public AudioSource audio;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") //Si colisionan con el jugador ocurre
        {
            ObjPuntos.GetComponent<Puntos>().puntos += cantidadPuntos; //Añadimos puntos
            audio.Play(); //Play el audio de recolección
            Destroy(gameObject); //Destruimos el objeto
        }
    }
}