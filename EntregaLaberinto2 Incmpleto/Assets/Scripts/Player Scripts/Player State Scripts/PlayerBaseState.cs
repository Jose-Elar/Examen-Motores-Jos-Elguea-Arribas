using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Clase Base Para la Maquina de Estados del Personaje
public abstract class PlayerBaseState
{
    public abstract void EnterState(PlayerStateManager playerState);

    public abstract void UpdateState(PlayerStateManager playerState);
}
