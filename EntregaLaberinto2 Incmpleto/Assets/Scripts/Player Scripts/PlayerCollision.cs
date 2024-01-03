using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script para lidiar con las colisiones del personaje
public class PlayerCollision : MonoBehaviour
{

    public bool collisionTrap = false;

    //Solo nos sera necesario el tocarlo por primera vez
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trap")
        {
            print("Enter");
            collisionTrap = true;
        }
    }


    //Probable codigo a eliminar porque el jugador cuando toque la trampa sera teletransportado al inicio del laberinto y no tendra tiempo de ni estar en el objeto ni salir
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Trap")
        {
            print("Stay");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Trap")
        {
            print("Exit");
            collisionTrap = false;
        }
    }




}
