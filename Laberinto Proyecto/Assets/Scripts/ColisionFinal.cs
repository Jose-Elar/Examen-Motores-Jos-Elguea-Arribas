using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionFinal : MonoBehaviour
{
    //Clase que sirve para mostrar el texto de victoria al tocar un cubo en el final
    public GameObject textoFinal;


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "final")
        {
            textoFinal.SetActive(true);
        }

    }
}
