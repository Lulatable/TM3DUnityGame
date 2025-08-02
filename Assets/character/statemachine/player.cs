using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class player 
{
    // Start is called before the first frame update
    public idleState idleState;
    public moveState moveState;
    public croucheIdleState crouchIdleState;
    public crouchMoveState crouchMoveState;

    private PlayerStateMachine stateMachine;

        public player(caractercontrol _control, Animator _animationController)
        {
            stateMachine = new PlayerStateMachine();
            idleState = new idleState(_control, stateMachine, _animationController, "Idle");
            moveState = new moveState(_control, stateMachine, _animationController, "Slow Run");
            crouchIdleState = new croucheIdleState(_control, stateMachine, _animationController, "Idle Crouch");
            crouchMoveState = new crouchMoveState(_control, stateMachine, _animationController, "Crouch");

            stateMachine.InitializeStateMachine(idleState);
        }

    

    // Update is called once per frame
    public PlayerState Update()
    {
        PlayerState theState = stateMachine._CurrentState;
        stateMachine._CurrentState.LogicUpdate();
        stateMachine._CurrentState.PhysicsUpdate();
        if(theState != stateMachine._CurrentState)
        {
            return stateMachine._CurrentState;
        }
        return null;
    }
}
