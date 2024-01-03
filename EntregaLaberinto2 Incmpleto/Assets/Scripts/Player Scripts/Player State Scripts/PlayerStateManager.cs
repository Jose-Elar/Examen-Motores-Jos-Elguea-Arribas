using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que modifica el estado de la maquina de estados del jugador
public class PlayerStateManager : MonoBehaviour
{


    PlayerBaseState currentState; //Estado Actual del jugador

    //Posibles estados
    public AliveState aliveState = new AliveState();
    public DeadState deadSate = new DeadState();

    // Start is called before the first frame update
    void Start()
    {
        //Estado inicial de la maquina de estados
        currentState = aliveState;

        currentState.EnterState(this); //This es la instancia del estado actual llamando a su metodo
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this); //Llamada a la funcion de actualizar para que haga los cambios necesarios 
    }

    //Funcion para cambiar el estado actual
    public void switchState(PlayerBaseState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }
}
