using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Action OnPlayerDamage;
    [SerializeField] private float _health = 100;

    public void Damage(float amount) {
        //(3f - (_health * (_health / 10000)))/10;  for vignette effect
        if (_health > 0) {
            OnPlayerDamage?.Invoke();
        }
        _health -= amount;
    }
}
