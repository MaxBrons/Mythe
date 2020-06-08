using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Weapon _equipedWeapon;
    [SerializeField] private GameObject _enemyHitSound;
    private InputMaster _inputMaster;
    private Animator _animator;
    private bool _animationIsRunning = false;
    private bool _attackButtonPressed = false;

    private void OnEnable() {
        //Enables the input scheme and then sets the values of the input to the corresponding function when performed
        _inputMaster.Player.Attack.Enable();
        _inputMaster.Player.Attack.performed += ctx => Attack();
    }
    private void OnDisable() {
        //Disables the input scheme
        _inputMaster.Player.Attack.Disable();
    }

    private void Awake() {
        _inputMaster = new InputMaster();
        _animator = GetComponent<Animator>();
    }

    public void Attack() {
        //if (_animationIsRunning) return;

        //Check if a civilian is in range
        CalculateDistanceFromCivilian(); 

        //Start Attack animation
        SwitchAnimationRunningBool(); 
        //_animator.Play("Start Attack");
    }

    private void CalculateDistanceFromCivilian() {
        //Shoot a raycast to check if a Civilian is in range
        RaycastHit hit;
        if(Physics.Raycast(transform.parent.position,transform.parent.forward,out hit, _equipedWeapon.GetWeaponRange(), 1 << 10)) {
            //Damages the Civilian that the ray hits
            hit.transform.GetComponent<CV_Health>().TakeDamage(_equipedWeapon.GetWeaponDamage());

            //Spawn the hit sound
            Instantiate(_enemyHitSound, hit.transform.position, Quaternion.identity);
        }
    }

    public void SwitchAnimationRunningBool() => _animationIsRunning = !_animationIsRunning;
    public void SetEquipedWeapon(Weapon weapon) => _equipedWeapon = weapon;
}
