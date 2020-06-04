using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Civilian : MonoBehaviour
{
    /// <summary>
    /// Holds all variables that the civilian/navmeshagent has
    /// </summary>
    [SerializeField] private NavMeshAgent _navAgent;
    [SerializeField] private float _health = 100;
    [SerializeField] private float _movementSpeed = 3.5f;
    [SerializeField] private float _attackSpeed = 1;
    [SerializeField] private float _attackRange = 3;
    [SerializeField] private float _attackDamage = 10;
    [SerializeField] private float _sightRange = 10;
    [SerializeField] private float _hearingRange = 30;
    [SerializeField] private GameObject _target = null;
    private void Awake() {
        _navAgent = _navAgent ? _navAgent : GetComponent<NavMeshAgent>();
        _navAgent.stoppingDistance = _attackRange - 0.5f;
        _navAgent.speed = _movementSpeed;
    }

    #region Getters & Setters
    public float GetHealth() { return _health; }
    public void SetHealth(float value) => _health = value;
    public float GetMovementSpeed() { return _navAgent.speed; }
    public void SetMovementSpeed(float value) => _navAgent.speed = value;
    public float GetAttackSpeed() { return _attackSpeed; }
    public void SetAttackSpeed(float value) => _attackSpeed = value;
    public float GetAttackDamage() { return _attackDamage; }
    public float GetAttackRange() { return _attackRange; }
    public float GetSightRange() { return _sightRange; }
    public float GetHearingRange() { return _hearingRange; }
    public NavMeshAgent GetNavMeshAgent() { return _navAgent; }
    public void SetTarget(GameObject target) => _target = target;
    public GameObject GetTarget() { return _target; }
    #endregion
}
