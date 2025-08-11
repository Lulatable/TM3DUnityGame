using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dyingState : ClassicSuperState
{
    private int countDeath = 0;

    public dyingState(caractercontrol _control, PlayerStateMachine _stateMachine, Animator _animationController, string _animationName) : base(_control, _stateMachine, _animationController, _animationName)
    {
        
    }


    public override void Enter()
    {
        

        if (countDeath == 0) 
        {
            animationController.SetTrigger(animationName);
            countDeath = 1;
        }

    }
    public override void Repeat()
    {
        return;
    }


    public override void Exit()
    {
        return;
    }
    public override void AnimationTrigger()
    {
        return;
    }
    public override void TransitionChecks()
    {
        return;
    }
    public override void PhysicsUpdate()
    {
        return;

    }

}
