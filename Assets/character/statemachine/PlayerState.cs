using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    // pas monobehaviour pour ne pas prendre trop de place
    protected caractercontrol control;
    protected PlayerStateMachine stateMachine;
    protected Animator animationController;
    protected string animationName;

    protected bool isExitingState;
    protected bool isAnimationFinished;
    protected float startTime;

    

    public PlayerState(caractercontrol _control , PlayerStateMachine _stateMachine, Animator _animationController ,string _animationName) {
        control = _control;
        stateMachine = _stateMachine;
        animationController = _animationController;
        animationName = _animationName;
        isExitingState = true;
    }

    public virtual void Enter()
    {
        isAnimationFinished = false;
        isExitingState = false;
        startTime = Time.time;
        //animationController.SetBool(animationName, true);
        animationController.SetTrigger(animationName);

      
    }

    public virtual void Repeat()
    {
        AnimatorStateInfo info = animationController.GetCurrentAnimatorStateInfo(0);
        if(!info.IsName(animationName))
        {
            animationController.SetTrigger(animationName);
        }
    }


    public virtual void Exit()
    {
        isExitingState = true;
        if (!isAnimationFinished) isAnimationFinished = true;
        
        
        //animationController.SetBool(animationName, false);
    }
    public virtual void LogicUpdate()
    {
        TransitionChecks();
        
    }
    public virtual void PhysicsUpdate() { }
    public virtual void TransitionChecks() 
    {
        AnimatorStateInfo info = animationController.GetCurrentAnimatorStateInfo(0);
        if (info.normalizedTime > 1 && !animationController.IsInTransition(0))
        {
            animationController.SetTrigger(animationName);
        }
    }
    

    public virtual void AnimationTrigger() 
    {
        isAnimationFinished = true;
    }
}
