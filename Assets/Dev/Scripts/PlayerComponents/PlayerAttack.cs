using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Weapon _equipedWeapon;
    [SerializeField] private GameObject _enemyHitSound;
    private InputMaster _inputMaster;
    private PlayerAnimationController _controller;
    private bool _animationIsRunning = false;

    private void Awake() {
        _inputMaster = Player.Instance && Player.Instance._inputMaster != null ? Player.Instance._inputMaster : new InputMaster();
        _controller = GetComponent<PlayerAnimationController>();
    }

    private void OnEnable() {
        //Enables the input scheme and then sets the values of the input to the corresponding function when performed
        _inputMaster.Player.Attack.Enable();
        _inputMaster.Player.Attack.performed += ctx => StartCoroutine(Attack());
    }
    private void OnDisable() {
        //Disables the input scheme
        _inputMaster.Player.Attack.performed -= ctx => StartCoroutine(Attack());
        _inputMaster.Player.Attack.Disable();
    }


    public IEnumerator Attack() {
        if (_animationIsRunning) yield break;
        SwitchAnimationRunningBool();

        _controller.SetBool(Constants._Attack_Bool,_animationIsRunning); //Turn on the attack animation
        AttackCivilian(); //Damage the civilian

        //Wait until the animation is done playing
        yield return new WaitForSeconds(_controller.GetCurrentClipLenght()*0.75f);
        SwitchAnimationRunningBool();
        _controller.SetBool(Constants._Attack_Bool, _animationIsRunning); //Turn on the attack animation
    }

    private void AttackCivilian() {
        //Shoot a raycast to check if a Civilian is in range
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _equipedWeapon.GetWeaponRange(), 1 << 10)) {
            //Damages the Civilian that the ray hits
            hit.transform.GetComponent<CV_Health>().TakeDamage(_equipedWeapon.GetWeaponDamage());

            //Spawn the hit sound
            GameObject sound = Instantiate(_enemyHitSound, hit.transform.position, Quaternion.identity);
            Destroy(sound, 3f);
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, _equipedWeapon.GetWeaponRange(), 1 << 12)) {
            if (SceneManager.GetActiveScene().buildIndex != 5) return;
            //Damages the Civilian that the ray hits
            hit.transform.GetComponent<Annie_Health>().TakeDamage(_equipedWeapon.GetWeaponDamage());

            //Spawn the hit sound
            GameObject sound = Instantiate(_enemyHitSound, hit.transform.position, Quaternion.identity);
            Destroy(sound, 3f);
        }
    }

    public void SwitchAnimationRunningBool() => _animationIsRunning = !_animationIsRunning;
    public void SetEquipedWeapon(Weapon weapon) => _equipedWeapon = weapon;
}
