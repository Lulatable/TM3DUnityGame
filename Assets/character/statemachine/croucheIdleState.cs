using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class croucheIdleState : ClassicSuperState
{
    public croucheIdleState(caractercontrol _control, PlayerStateMachine _stateMachine, Animator _animationController, string _animationName) : base(_control, _stateMachine, _animationController, _animationName)
    {
    }

    public override void TransitionChecks()
    {
        base.TransitionChecks();
        if (!isMoving && isCrouching) stateMachine.ChangeState(control.player.crouchIdleState);
    }
}
