using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CV_Idle : CV_State
{
    public override void Awake() => base.Awake();

    //Gets called when the state is set to active state
    public override void StartState() {
        base.StartState();
        _civilian.SetMovementSpeed(0); //Sets the movement speed of the NavMeshAgent
    }

    //Gets called when you break out of the state by switching to an other state
    public override void StopState() {
        base.StopState();
    }

    //This is where the funtionality of the state is performed
    public override void PerformState() {
        //Play idle animation
    }

    //This is to check when to break out of a state or to switch to an other state
    public override void RequestToStopState() {
        //Checks if a player is in range
        Collider[] _inRangeObjects = Physics.OverlapSphere(transform.position, _civilian.GetSightRange(), 1 << 9);
        if (_inRangeObjects.Length < 1) return;

        //Switches to the Attack state because a player is in range
        _civilian.SetTarget(_inRangeObjects[0].gameObject);
        _stateMachine.SwitchState(2);
    }
}
