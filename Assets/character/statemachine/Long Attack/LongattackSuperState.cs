using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongAttackSuperState : PlayerState
{
    public LongAttackSuperState(caractercontrol _control, PlayerStateMachine _stateMachine, Animator _animationController, string _animationName) : base(_control, _stateMachine, _animationController, _animationName)
    {
    }

    protected bool isLongAttacking;
    protected bool isShortAttacking;


    public override void TransitionChecks()
    {
        base.TransitionChecks();
        

    }
    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }
}
