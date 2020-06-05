using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CV_Health : MonoBehaviour
{
    private float _health = 100;
    private void Start() => _health = GetComponent<Civilian>().GetMaxHealth();

    //Damages the civilian
    public void TakeDamage(float amount) {
        if(_health <= 0) {
            GetComponent<CV_StateMachine>().SwitchState(3);
            return;
        }
        _health -= amount;
    }
}
