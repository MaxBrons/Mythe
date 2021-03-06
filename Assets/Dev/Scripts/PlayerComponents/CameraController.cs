﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera), typeof(Rigidbody))]
public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _objectToFollow; //This is the object the camera will stick to
    [SerializeField] private float _distanceFromObject = 10; //The distance away from the object it follows
    [SerializeField] private float _heightFromObject = 3; //The distance it stays above the object it follows
    private Rigidbody _rb;
    private InputMaster _inputMaster;
    private Vector2 _lookDirection;
    private float _xRotation = 0;

    private void Start() {
        _inputMaster = Player.Instance && Player.Instance._inputMaster != null ? Player.Instance._inputMaster : new InputMaster();
        _rb = GetComponent<Rigidbody>();

        //Sets the values of the input to the corresponding stored variables
        _inputMaster.Player.Look.Enable();
        _inputMaster.Player.Look.performed += ctx => _lookDirection = ctx.ReadValue<Vector2>();
    }

    private void Update() {
        //Sets the Camera's position to the position of the object it follows
        if (_objectToFollow)
            transform.position = _objectToFollow.position + new Vector3(0, _heightFromObject, _distanceFromObject);
    }

    private void FixedUpdate() {
        if (_lookDirection != Vector2.zero) RotatePlayer();

        if (_objectToFollow) {
            //Updates the rotation of the object the camera is following depending on the mouse position of the player
            _objectToFollow.GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(new Vector3(0, _rb.rotation.eulerAngles.y, 0)));
        }
    }

    private void RotatePlayer() {
        //Clamps the camera's y axis
        Vector3 mousePosition = new Vector3(_lookDirection.y, _lookDirection.x, 0) * Settings._mouseSensitivity * Time.deltaTime;

        _xRotation -= mousePosition.x;
        _xRotation = Mathf.Clamp(_xRotation, -45f, 45f);

        //Rotates the camera to the position of the mouse
        _rb.MoveRotation(Quaternion.Euler(_xRotation, transform.eulerAngles.y + mousePosition.y, 0f));
    }
}
