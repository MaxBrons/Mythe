using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 1f; //The rate at wich the player moves
    [SerializeField] private float _sprintSpeed = 1f; //The rate at wich the player sprints

    private Rigidbody _rb;

    private void Start() {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update() {
        //Adds an value to the vector depending on wich key is pressed
        Vector3 _movement = Vector3.zero;
        _movement += Input.GetKey(KeyCode.W) ? transform.forward : Vector3.zero;
        _movement += Input.GetKey(KeyCode.A) ? -transform.right : Vector3.zero;
        _movement += Input.GetKey(KeyCode.S) ? -transform.forward : Vector3.zero;
        _movement += Input.GetKey(KeyCode.D) ? transform.right : Vector3.zero;
        _movement.Normalize();

        //Sets the player sprint speed when shift is pressed
        float _playerSprintSpeed = Input.GetKey(KeyCode.LeftShift) ? _sprintSpeed : 1;

        //Moves the player in the _movement vector's direction
        if (_movement.magnitude > 0 && _movement != Vector3.zero)
            _rb.MovePosition(transform.position + _movement * _playerSprintSpeed * _movementSpeed * Time.deltaTime);
    }
}
