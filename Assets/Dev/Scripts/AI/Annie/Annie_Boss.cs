using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Annie_Boss : MonoBehaviour
{
    [SerializeField] private float _attackProbability;
    [SerializeField] private float _timeForNextAttack;
    [SerializeField] private float _maxAttackDamage;
    [SerializeField] private GameObject[] _attacks;
    private Animator _animator;
    private NavMeshAgent _agent;
    private GameObject _player;
    private Rigidbody _rb;
    private float rand = 0;

    private void Awake() {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _player = GameObject.FindGameObjectWithTag(Constants._mainPlayer);
    }

    private void Start() {
        StartCoroutine(CheckForAttack());
    }

    private void LateUpdate() {
        _agent.SetDestination(_player.transform.position);
        transform.LookAt(_player.transform);
    }
    private IEnumerator CheckForAttack() {
        while (true) {
            rand = Random.Range(0, 1 / _attackProbability);
            StartCoroutine(PerformAttack());
            yield return new WaitForSeconds(_timeForNextAttack);
        }
    }
    private IEnumerator PerformAttack() {
        _animator.SetBool(Constants._Attack_Bool, true);
        rand = Random.Range(0, 2);
        GameObject obj = rand == 0 ? _attacks[0] : _attacks[1];
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0).Length);
        if (rand == 1) {
            GameObject fire = Instantiate(obj, _player.transform.position, obj.transform.rotation);
            Destroy(fire, 3f);
            _player.GetComponent<PlayerHealth>().Damage(Random.Range(0, _maxAttackDamage));
        }
        else Instantiate(obj, _player.transform.position - new Vector3(rand + 1 * 2, 0, rand + 1 * 2), Quaternion.identity);

        _animator.SetBool(Constants._Attack_Bool, false);
    }
}
