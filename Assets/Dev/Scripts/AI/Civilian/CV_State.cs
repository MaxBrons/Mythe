using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent),typeof(CV_StateMachine))]
public abstract class CV_State : MonoBehaviour
{
    /// <summary>
    /// Base script that every state inherits from
    /// </summary>
    protected CV_StateMachine _stateMachine;
    protected Civilian _civilian;
    protected Animator _animator;
    protected EventHandler _eventHandler;

    public virtual void Awake() {
        _civilian = GetComponent<Civilian>();
        _stateMachine = GetComponent<CV_StateMachine>();
        _eventHandler = EventHandler.Instance;
        //_animator = GetComponent<Animator>();
    }

    //This is called when state is set as active state
    public virtual void StartState() {
    }

    //This is called when you break out of the state by switching to an other state
    public virtual void StopState() {
    }

    public abstract void PerformState(); //This is where the functionality of the state if performed
    public abstract void RequestToStopState(); //This is to check when to break out of the state
}
