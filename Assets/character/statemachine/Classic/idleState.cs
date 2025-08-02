using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleState : ClassicSuperState
{
    public idleState(caractercontrol _control, PlayerStateMachine _stateMachine, Animator _animationController, string _animationName) : base(_control, _stateMachine, _animationController, _animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();
       // animationController.SetBool(animationName, true);
        
    }

    public override void Repeat()
    {
        base.Repeat();
    }

    public override void Exit()
    {
        base.Exit();
        //animationController.SetBool(animationName, false);
    }


    public override void TransitionChecks()
    {
        base.TransitionChecks();
        if (isMoving && !isCrouching) stateMachine.ChangeState(control.player.moveState);
        if (!isMoving && isCrouching) stateMachine.ChangeState(control.player.crouchIdleState);
        
    }
    public override void AnimationTrigger()
    { 
        base.AnimationTrigger();
    }
}
