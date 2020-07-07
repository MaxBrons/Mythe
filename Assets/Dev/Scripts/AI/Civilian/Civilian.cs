using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Civilian : MonoBehaviour
{
    /// <summary>
    /// Holds all variables that the civilian/navmeshagent has
    /// </summary>
    [SerializeField] private NavMeshAgent _navAgent;
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private float _movementSpeed = 3.5f;
    [SerializeField] private float _attackSpeed = 1;
    [SerializeField] private float _attackRange = 3;
    [SerializeField] private float _stoppingRange = 2.5f;
    [SerializeField] private float _attackDamage = 10;
    [SerializeField] private float _sightRange = 10;
    [SerializeField] private float _hearingRange = 30;
    [SerializeField] private GameObject _target = null;
    [SerializeField] private Transform _civilianBodyPelvis;
    private bool dead = false;
    private void Awake() {
        _navAgent = _navAgent ? _navAgent : GetComponent<NavMeshAgent>();
        _navAgent.stoppingDistance = _stoppingRange;
        _navAgent.speed = _movementSpeed;
        TogglePelvisRigidBodies(true);
    }

    public void TogglePelvisRigidBodies(bool kinematic) {
        if (!kinematic) DisableCivilian();
        _civilianBodyPelvis.transform.parent = !kinematic ? null : transform;
        _civilianBodyPelvis.gameObject.SetActive(!kinematic);
    }

    private void DisableCivilian() {
        //Disable all components that
        foreach (Behaviour i in gameObject.GetComponents<Behaviour>())
            i.enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
    }

    #region Getters & Setters
    public float GetMaxHealth() { return _maxHealth; }
    public float GetAttackDamage() { return _attackDamage; }
    public float GetAttackRange() { return _attackRange; }
    public float GetStoppingRange() { return _stoppingRange; }
    public float GetSightRange() { return _sightRange; }
    public float GetHearingRange() { return _hearingRange; }
    public NavMeshAgent GetNavMeshAgent() { return _navAgent; }
    public GameObject GetTarget() { return _target; }
    public Transform GetCivilianBodyPelvis() { return _civilianBodyPelvis; }
    public bool GetDeadState() { return dead; }
    public void SetDeadState(bool state) => dead = state;
    public void SetMovementSpeed(float value) => _navAgent.speed = value;
    public void SetTarget(GameObject target) => _target = target;
    public void SetCivilianDestination(Vector3 destination) => _navAgent.SetDestination(destination);
    #endregion
}
