using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine 
{
    // ici on tient compte du state actuel,on initialise le 1er + on passe de state en state 

    public PlayerState _CurrentState;

    

    public void ChangeState(PlayerState newState)
    {
        _CurrentState.Exit();
        _CurrentState = newState;
        _CurrentState.Enter();
    }
    public void InitializeStateMachine(PlayerState initialState)
    {
        _CurrentState = initialState;
        _CurrentState.Enter();
    }
}
