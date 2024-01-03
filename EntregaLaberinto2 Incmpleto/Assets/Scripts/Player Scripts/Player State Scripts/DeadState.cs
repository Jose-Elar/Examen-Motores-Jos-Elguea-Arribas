using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Estado Muerto del Jugador
public class DeadState : PlayerBaseState
{
    public override void EnterState (PlayerStateManager playerState)
    {
        //Teletransportar jugador al inicio del laberinto
        Debug.Log("Jugador Teletransportado");
    }

    //Una vez ya transportado en el EnterState se cambia el estado lo antes posible de vuelta
    public override void UpdateState (PlayerStateManager playerState) 
    {
        playerState.switchState(playerState.aliveState); //Llamada al cambio del estado
    }
}
