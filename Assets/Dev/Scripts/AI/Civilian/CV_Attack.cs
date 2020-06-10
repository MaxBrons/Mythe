using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CV_Attack : CV_State
{
    private bool _attackAnimationRunning = false;

    public override void Awake() => base.Awake();

    //Gets called when the state is set to active state
    public override void StartState() {
        base.StartState();
        _civilian.SetMovementSpeed(5); //Sets the movement speed of the NavMeshAgent
        _civilian.GetNavMeshAgent().stoppingDistance = _civilian.GetAttackRange(); //Sets the stopping distance of the NavMeshAgent
        _animator.SetBool(Constants._CV_Run_Bool, true);
    }

    //Gets called when you break out of the state by switching to an other state
    public override void StopState() {
        base.StopState();
        _animator.SetBool(Constants._CV_Run_Bool, false);
    }

    //This is where the funtionality of the state is performed
    public override void PerformState() {
        //Moves the civilian to the position of its 
        if (!_civilian.GetTarget()) return;
        _civilian.SetCivilianDestination(_civilian.GetTarget().transform.position);

        //Attacks the player, if close enough to attack
        if (_attackAnimationRunning) return;
        if (Vector3.Distance(transform.position, _civilian.GetTarget().transform.position) < _civilian.GetAttackRange()) {
            StartCoroutine(Attack());
        }
    }

    //This is to check when to break out of a state or to switch to an other state
    public override void RequestToStopState() {
        //Switches the active state to Idle because target is not found
        if (!_civilian.GetTarget()) {
            _stateMachine.SwitchState(0);
            return;
        }

        //Switches the active state to Idle because the target is out of range
        if (Vector3.Distance(transform.position, _civilian.GetTarget().transform.position) > _civilian.GetSightRange()) {
            _stateMachine.SwitchState(1);
        }
    }

    //This is called when a player is close enough to be attacked
    private IEnumerator Attack() {
        _animator.SetBool(Constants._CV_Attack_Bool, true);
        _attackAnimationRunning = true;

        yield return new WaitForSeconds(.5f);

        if (_civilian.GetTarget())
            _civilian.GetTarget().GetComponent<PlayerHealth>().Damage(_civilian.GetAttackDamage());
        
        _animator.SetBool(Constants._CV_Attack_Bool, false);
        _attackAnimationRunning = false;
    }
}
