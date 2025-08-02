using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicSuperState : PlayerState
{
    public ClassicSuperState(caractercontrol _control, PlayerStateMachine _stateMachine, Animator _animationController, string _animationName) : base(_control, _stateMachine, _animationController, _animationName)
    {
    }
    protected bool isMoving;
    protected bool isCrouching;
    

    public override void LogicUpdate()
    {
        isMoving = variableManager.instance.isMoving;
        isCrouching = variableManager.instance.Crouch;
       
        base.LogicUpdate();
        

    }

}
