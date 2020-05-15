using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 1;
    [SerializeField] private float _movementSpeed = 1f;
    [SerializeField] private float _sprintSpeed = 1f;
    //[SerializeField] private float _movementSteps = 1f;
    [SerializeField] private float _movementMagnitude = 2f;
    private Rigidbody _rb;

    private void Start() {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        //Rotate the player to the mouse position
        Vector3 mousePos = new Vector3(0, Input.GetAxis("Mouse X"), 0);
        transform.eulerAngles += mousePos;

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
        if (_movement.magnitude <= _movementMagnitude && _movement != Vector3.zero)
            transform.position += _movement * _playerSprintSpeed * _movementSpeed * Time.deltaTime;
    }
}
