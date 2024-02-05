using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuerta3 : MonoBehaviour
{
    // Los que pongamos como public los podremos modificar desde el inspector
    public GameObject puerta; // Referencia al cubo que act�a como puerta
    public float DistanciaMax = 0.5f; // M�xima distancia a la que el Raycast ser� efectivo
    public float VelocidadMov = 1f; // Velocidad de movimiento de la puerta
    private bool abriendo = false; // Para controlar si la puerta se est� abriendo
    private Vector3 PosicionInicial; // Para almacenar la posici�n inicial de la puerta
    private float DistanciaMov = 0f; // Para rastrear la distancia que se ha movido

    void Start()
    {
        PosicionInicial = puerta.transform.position; // Almacenar la posici�n inicial
    }


    // Con el siguiente c�digo veremos si el Raycast colisona con un objeto que tiene el tag "interruptor" y empieza a abrir la puerta a una velocidad concreta,
    //hasta una distacia concreta y para la puerta cuando llega a la distancia indicada.
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, DistanciaMax))
        {
            if (hit.collider.gameObject.CompareTag("interruptor2"))
            {
                abriendo = true;
            }
        }

        if (abriendo && DistanciaMov < 2f)
        {
            float moveThisFrame = VelocidadMov * Time.deltaTime;
            puerta.transform.Translate(-moveThisFrame, 0, 0);

            DistanciaMov += Mathf.Abs(moveThisFrame);

            if (DistanciaMov >= 2f)
            {
                abriendo = false;
            }
        }
    }
}