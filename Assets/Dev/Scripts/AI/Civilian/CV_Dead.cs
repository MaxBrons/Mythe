using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CV_Dead : CV_State
{
    public event Action<GameObject> OnCivilianDeath;
    public override void Awake() => base.Awake();
    public override void StartState() {
        OnCivilianDeath?.Invoke(gameObject);

        //Activate the ragdoll and destroy the civilian after an amount of time
        _civilian.TogglePelvisRigidBodies(false);
        Destroy(_civilian.GetCivilianBodyPelvis().gameObject, 10f);
        Destroy(gameObject, 10f);
    }

    public override void StopState() { }
    public override void PerformState() { }
    public override void RequestToStopState() { }
}
