using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    float Speed = 4f;// Velocidad a la que se mueve los muros con interruptor

    public Camera playerCam; //Camara para calcular los raycasts
    float range = 5f; // Rango del Raycast

    //Textos para activar y desactivar 
    public GameObject buttonText;
    public GameObject pressText;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit; //Variable donde almacenamos la info del RayCast
        if ((Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range)) && (hit.transform.tag == "Button") ) //Comprobamos el RayCast y que lo que tenemos delante es un boton
        {
            buttonText.SetActive(true); //Enseñar texto

            if (Input.GetKeyDown(KeyCode.E)) //Comprobar tecla
            {
                hit.transform.gameObject.tag = "Used_Button"; //Quitamos la tag al objeto para que no se pueda volver a usar
                StartCoroutine(DelayText()); //LLamada a la funcion para enseñar el texto con un delay

                if(hit.transform.parent.tag == "Wall") //Excepcion de 1 trampa
                {
                    hit.transform.parent.Translate(Vector3.right * Speed); //Movemos la pared
                }
                else
                {
                    hit.transform.parent.Translate(Vector3.left * Speed); //Movemos la pared
                }

            }
        } else
        {
            buttonText.SetActive (false); //
        }
    }

    //Funcion para enseñar el texto de pulsar el boton bien
    private IEnumerator DelayText()
    {
        pressText.SetActive(true);
        yield return new WaitForSeconds(2);
        pressText.SetActive(false);
    }
}

