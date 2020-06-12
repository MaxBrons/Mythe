using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using TMPro;

public class Annie_Boss : MonoBehaviour
{
    [SerializeField] private float _attackProbability;
    [SerializeField] private float _timeForNextAttack;
    [SerializeField] private float _maxTravelDistance;
    [SerializeField] private float _maxAttackDamage;
    private Animator _animator;
    private NavMeshAgent _agent;
    private GameObject _player;

    private void Awake() {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag(Constants._mainPlayer);
    }

    private void Start() {
        StartCoroutine(CheckForAttack());
        _agent.SetDestination(transform.position);
    }

    private void LateUpdate() {
        if (transform.position != _agent.destination) return;
        _agent.SetDestination(transform.position + new Vector3(Random.Range(0, _maxTravelDistance), 0, Random.Range(0, _maxTravelDistance)));
    }
    private IEnumerator CheckForAttack() {
        while (true) {
            float rand = Random.Range(0, 1 / _attackProbability);
            if (rand == 0) StartCoroutine(PerformAttack());
            yield return new WaitForSeconds(_timeForNextAttack);
        }
    }
    private IEnumerator PerformAttack() {
        _animator.SetBool(Constants._Attack_Bool, true);

        yield return new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0).Length);
        _player.GetComponent<PlayerHealth>().Damage(Random.Range(0,_maxAttackDamage));

        _animator.SetBool(Constants._Attack_Bool, false);
    }
}
