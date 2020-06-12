using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 1f; //The rate at wich the player moves
    [SerializeField] private int _sprintSpeedMultiplier = 1; //The rate at wich the player sprints
    private bool _isSprinting = false; //Is set to true if left shift is pressed
    private InputMaster _inputMaster; //Control scheme from Unity's new input system
    //private PlayerAnimationController _controller;
    private Rigidbody _rb;
    private Vector2 _moveDirection = new Vector2();

    private void Start() {
        _inputMaster = Player.Instance._inputMaster;
        _rb = GetComponent<Rigidbody>();
        //_controller = GetComponent<PlayerAnimationController>();

        //Sets the values of the input to the corresponding stored variables
        _inputMaster.Player.Move.Enable();
        _inputMaster.Player.Sprint.Enable();
        _inputMaster.Player.Move.performed += ctx => _moveDirection = ctx.ReadValue<Vector2>();
        _inputMaster.Player.Sprint.performed += ctx => _isSprinting = ctx.ReadValueAsButton();
    }

    private void FixedUpdate() {
        MovePlayer();
    }
    private void MovePlayer() {
        if (_moveDirection == Vector2.zero) return;
        //_controller.SetBool(Constants._Move_Bool, (_moveDirection == Vector2.zero ? false : true));

        //Sets a vector to the transform direction of the player depending on wich key was pressed
        Vector3 _movement = transform.right * _moveDirection.x + transform.forward * _moveDirection.y;
        _movement.Normalize();

        //Sets the sprint speed depending on if the left shift key is pressed and the player is moving forward
        float _sprintSpeed = (_isSprinting && _moveDirection.y > 0) ? _sprintSpeedMultiplier : 1;
        //_controller.SetBool(Constants._Run_Bool, (_sprintSpeed == 1 ? false : true));

        //Moves the player in the _movement vector's direction with a set speed
        _rb.MovePosition(transform.position + _movement * _movementSpeed * _sprintSpeed * Time.fixedDeltaTime);
    }
}
