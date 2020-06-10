using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CV_Move : CV_State
{
    private void OnEnable() {
        if(_eventHandler) _eventHandler.OnPlayerMakingNoice += MoveTowardsNoice;
    }
    private void OnDisable() {
        if (_eventHandler) _eventHandler.OnPlayerMakingNoice -= MoveTowardsNoice;
    }
    public override void Awake() => base.Awake();

    //Gets called when the state is set to active state
    public override void StartState() {
        base.StartState();
        _civilian.SetMovementSpeed(3.5f); //Sets the movement speed of the NavMeshAgent
        _animator.SetBool(Constants._CV_Move_Bool, true);

        if (!_civilian.GetTarget()) return;
        _civilian.SetCivilianDestination(_civilian.GetTarget().transform.position);
        _civilian.SetTarget(null);
    }

    //Gets called when you break out of the state by switching to an other state
    public override void StopState() {
        base.StopState();
        _animator.SetBool(Constants._CV_Move_Bool, false);
    }

    //This is where the funtionality of the state is performed
    public override void PerformState() {
    }

    //This is to check when to break out of a state or to switch to an other state
    public override void RequestToStopState() {
        //Let's the civilian follow the last known position of it's target or switch to Idle state
        if (_civilian.GetNavMeshAgent().hasPath) {
            if (_civilian.GetNavMeshAgent().remainingDistance > _civilian.GetNavMeshAgent().stoppingDistance) return;
            _stateMachine.SwitchState(0);
        }

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
        _civilian.SetCivilianDestination(target);
    }
}
