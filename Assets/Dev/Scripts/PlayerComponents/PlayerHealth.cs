using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _health = 100;
    private EventHandler _eventHandler;

    private void Start() {
        _eventHandler = EventHandler.Instance;
    }
    public void Damage(float amount) {
        //(3f - (_health * (_health / 10000)))/10;  for vignette effect
        if (_health <= 0) {
            Destroy(gameObject);
            return;
        }
        _eventHandler.DamagePlayer();
        _eventHandler.PlayerMadeNoice(transform.position);
        _health -= amount;
    }
}
