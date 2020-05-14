using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _objectToFollow;
    [SerializeField] private float _distanceFromObject = 10;
    [SerializeField] private float _heightFromObject = 3;
    [SerializeField] private float _rotationSpeed = 1;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update() {
        transform.position = _objectToFollow.position + new Vector3(0, _heightFromObject, _distanceFromObject);
        Vector3 mousePos = new Vector3(-Mathf.Clamp(Input.GetAxis("Mouse Y"), -15, 15), Input.GetAxis("Mouse X"), 0);
        transform.eulerAngles += mousePos;
    }
}
