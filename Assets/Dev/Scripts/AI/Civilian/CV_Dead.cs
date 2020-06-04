using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CV_Dead : CV_State
{
    public override void Awake() => base.Awake();
    public override void StartState() {
        base.StartState();
        _eventHandler.OnPlayerMakingNoice -= GetComponent<CV_Move>().MoveTowardsNoice;
        Debug.Log("Dead");
    }

    public override void StopState() {
        base.StopState();
    }

    public override void PerformState() {
        //Player animation
    }
    public override void RequestToStopState() {
    }
}
