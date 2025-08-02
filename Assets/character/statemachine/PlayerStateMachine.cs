using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine 
{
    // ici on tient compte du state actuel,on initialise le 1er + on passe de state en state 

    public PlayerState _CurrentState;

    

    public PlayerState ChangeState(PlayerState newState)
    {
        if (_CurrentState == newState)
        {
            return _CurrentState;
        }
        
        _CurrentState.Exit();
        _CurrentState = newState;
        _CurrentState.Enter();
        return _CurrentState;
    }
    public void InitializeStateMachine(PlayerState initialState)
    {
        _CurrentState = initialState;
        _CurrentState.Enter();
    }
}
