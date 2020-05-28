﻿using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private bool _destruct = false; //If true, this object will destroy itself on collision
    private void Start() {
        // Destroys the script or the entire object depending on if the script is set to destruct or not
        if (!_destruct) Destroy(gameObject, 10f);
        else Destroy(this, 5f);
    }

    //Destroys eather the object itself or the object it collides with
    private void OnTriggerEnter(Collider other) {
        if (_destruct) {
            Destroy(gameObject);
            return;
        }
        if (other.transform == transform.parent) return;
        Destroy(other.gameObject);
    }
}