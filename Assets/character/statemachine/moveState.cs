using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveState : ClassicSuperState
{
    public moveState(caractercontrol _control, PlayerStateMachine _stateMachine, Animator _animationController, string _animationName) : base(_control, _stateMachine, _animationController, _animationName)
    {
    }


    public override void Enter()
    {
        base.Enter();
        
    }

    public override void Exit()
    {
        base.Exit();
        
    }
    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void TransitionChecks()
    {
        base.TransitionChecks();
        
        if (!isMoving && !isCrouching) stateMachine.ChangeState(control.player.idleState);
        if (isMoving && isCrouching) stateMachine.ChangeState(control.player.crouchMoveState);
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
    }
}
