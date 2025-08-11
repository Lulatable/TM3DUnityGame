using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crouchMoveState : ClassicSuperState
{
    public crouchMoveState(caractercontrol _control, PlayerStateMachine _stateMachine, Animator _animationController, string _animationName) : base(_control, _stateMachine, _animationController, _animationName)
    {
    }
    public override void Enter()
    {
        base.Enter();
    }

    public override void Repeat()
    {
        base.Repeat();
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
        if (!isMoving && isCrouching && !isDying) stateMachine.ChangeState(control.player.crouchIdleState);
        if (!isMoving && !isCrouching && !isDying) stateMachine.ChangeState(control.player.moveState);
        if (isMoving && isCrouching && isDying) stateMachine.ChangeState(control.player.dyingState);
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
}
