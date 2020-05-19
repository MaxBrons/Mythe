using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera),typeof(Rigidbody))]
public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _objectToFollow; //This is the object the camera will stick to
    [SerializeField] private float _distanceFromObject = 10; //The distance away from the object it follows
    [SerializeField] private float _heightFromObject = 3; //The distance it stays above the object it follows
    [SerializeField] private float _rotationSpeed = 1; //The speed at wich the player rotates the camera
    [SerializeField] private float _lerpTime = 1;
    private Rigidbody _rb;

    private void Start() {
        //Hides and locks the players cursor in place
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;

        _rb = GetComponent<Rigidbody>();
    }
    private void Update() {
        //Sets the Camera's position to the position of the object it follows
        transform.position = _objectToFollow.position + new Vector3(0, _heightFromObject, _distanceFromObject);

        //Updates the camera rotation depending on the mouse position of the player
        Vector3 mousePos = new Vector3(-Mathf.Clamp(Input.GetAxis("Mouse Y"), -15, 15), Input.GetAxis("Mouse X"), 0);
        _rb.MoveRotation(Quaternion.Euler(_rb.rotation.eulerAngles + mousePos * _rotationSpeed * Time.deltaTime));

        //Updates the rotation of the object the camera is following depending on the mouse position of the player
        _objectToFollow?.GetComponent<Rigidbody>()?.MoveRotation(Quaternion.Euler(new Vector3(0, _rb.rotation.eulerAngles.y, 0)));
    }
}
