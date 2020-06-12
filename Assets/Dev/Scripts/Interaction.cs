using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    [SerializeField] private GameObject _keyImage;
    [SerializeField] private float _inRangeDistance = 6f;
    private GameObject _player;
    private bool _isActive;

    private void Start() => _player = GameObject.FindGameObjectWithTag(Constants._mainPlayer);

    private void FixedUpdate() {
        //if (!_isActive) return;
        if (InputSystem.GetDevice<Keyboard>().fKey.wasPressedThisFrame)
            PressedKey();
    }
    private void OnMouseEnter() {
        if (!_keyImage || Vector2.Distance(gameObject.transform.position, _player.transform.position) > _inRangeDistance) return;
        _isActive = true;
        _keyImage.SetActive(true);
    }
    private void OnMouseExit() {
        if (!_keyImage || !_keyImage.activeSelf) return;
        _isActive = false;
        _keyImage.SetActive(false);
    }

    private void PressedKey() {
        GetComponent<ObjectiveDoor>().OpenDoor();
    }
}
