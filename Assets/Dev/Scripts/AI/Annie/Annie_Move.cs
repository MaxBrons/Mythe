using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Annie_Move : MonoBehaviour
{
    private Animator _animator;
    private NavMeshAgent _agent;
    private GameObject _player;
    private Rigidbody _rb;
    private void Awake() {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _player = GameObject.FindGameObjectWithTag(Constants._mainPlayer);
    }

    private void Start() {
        int rand = (int)Mathf.Round(Random.Range(0, 3));
        transform.position = rand == 0 ? new Vector3(0,3,0) : rand == 1 ? new Vector3(-48,3,0) : new Vector3(-48, 3, 48);
    }

    private void LateUpdate() {
        _agent.SetDestination(_player.transform.position);
        transform.LookAt(_player.transform);
        if (Vector2.Distance(_player.transform.position, transform.position) <= _agent.stoppingDistance) {
            if (_animator.GetBool(Constants._Move_Bool)) _animator.SetBool(Constants._Move_Bool, false);
            return;
        }
        if (!_animator.GetBool(Constants._Move_Bool)) _animator.SetBool(Constants._Move_Bool, true);
    }
}
