using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CV_Move : CV_State
{
    public override void Start() {
        base.Start();
        _eventHandler.OnPlayerMakingNoice += MoveTowardsNoice; 
    }

    //Gets called when the state is set to active state
    public override void StartState() {
        base.StartState();
        _civilian.SetMovementSpeed(3.5f); //Sets the movement speed of the NavMeshAgent
    }

    //Gets called when you break out of the state by switching to an other state
    public override void StopState() {
        base.StopState();
    }

    //This is where the funtionality of the state is performed
    public override void PerformState() {
        //Play animation
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

    //This is called when a player makes a noticable sound
    public void MoveTowardsNoice(Vector3 target) {
        //Sets the destination of the civilian if no target is assigned or if the noice is in range
        if (_civilian.GetTarget() || Vector3.Distance(transform.position,target) > _civilian.GetHearingRange()) return;

        //Switches the active state to Moving if a player makes a noticable sound
        _stateMachine.SwitchState(1);
        _civilian.GetNavMeshAgent().SetDestination(target);
    }
}
