using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CV_Dead : CV_State
{
    public override void Awake() => base.Awake();
    public override void StartState() {
        _eventHandler.OnPlayerMakingNoice -= GetComponent<CV_Move>().MoveTowardsNoice;
        Debug.Log(transform.name + " died");
        Destroy(gameObject);
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
