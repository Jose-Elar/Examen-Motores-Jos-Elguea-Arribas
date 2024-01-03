using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Estado Normal del Jugador
public class AliveState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager playerState)
    {
        Debug.Log("Comienza la partida");
    }

    public override void UpdateState(PlayerStateManager playerState)
    {
        if(true) //Cambiar true por la condicion de colision con una trampa
        {
            playerState.switchState(playerState.deadSate); //Llamada al cambio del estado
        }
    }


}
