using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Muerte : MonoBehaviour
{
 

    public vidaPlayer vidaScript;

    bool disable = false; //Variable para poder desactivar la colision por un tiempo


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Variaciones de llamadas a reducir la vida del personaje dependiendo de a quien golpea
        if ((hit.collider.CompareTag("trampa") && !disable)) //Disable sirve para evirtar morir al instante al tocar algo que no te quita toda la vida
        {
            StartCoroutine(reducirVida(1.0f));
        }
        if (hit.collider.CompareTag("mover") && !disable)
        {
            StartCoroutine(reducirVida(2.0f));
        }
        if (hit.collider.CompareTag("trampaBola"))
        {
            StartCoroutine (reducirVida(4.0f));
        }

    }
    IEnumerator reducirVida(float reducir) //Metodo para poder introducir delay en llamadas
    {
        disable = true; 
        vidaScript.reducirVida(reducir);
        yield return new WaitForSeconds(0.5f);
        disable = false; 
    }



}