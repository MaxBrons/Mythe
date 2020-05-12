using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveSectionSpawnpoint : MonoBehaviour
{
    public enum SectionOpeningDirections
    {
        front = 0,
        back = 1,
        left = 2,
        right = 3
    }

    [SerializeField] private SectionOpeningDirections _spawnpointDirection = SectionOpeningDirections.front;
    [SerializeField] private GameObject _dependecySection = null;

    private CaveSectionTemplate _caveSectionTemplate;
    private const string _spawnpointTag = "Spawnpoint";
    private const string _caveSection = "CaveSection";
    private const string _CaveIntersection = "CaveIntersection";
    private bool _spawned = false;
    private int rand;

    private void Start() {
        _caveSectionTemplate = transform.parent.GetComponentInParent<CaveSectionTemplate>();
        Invoke("SpawnSection", 0.5f);
        Destroy(gameObject, 1f);
    }

    private void SpawnSection() {
        if (!_spawned) {
            if (!_dependecySection) {
                rand = Random.Range(0, _caveSectionTemplate.GetSpawnableSections((int)_spawnpointDirection).Length);
                GameObject obj = _caveSectionTemplate.GetSpawnableSections((int)_spawnpointDirection)[rand];
                Instantiate(obj, transform.position, obj.transform.rotation, transform.parent.parent);
            }
            else {
                Instantiate(_dependecySection, transform.position, _dependecySection.transform.rotation, transform.parent.parent);
            }
            _spawned = true;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (!_spawned) {
            if (other.tag == _spawnpointTag) {
                if (!other.GetComponent<CaveSectionSpawnpoint>().GetSpawnedBool()) {
                    Destroy(other.gameObject);
                    Instantiate(_caveSectionTemplate.GetIntersection(), transform.position, Quaternion.identity, transform.parent.parent);
                }
            }
            else if (other.tag == _caveSection && other.transform.childCount == 0) {
                if (transform.parent.tag != _CaveIntersection) {
                    Destroy(other.gameObject);
                    Instantiate(_caveSectionTemplate.GetIntersection(), transform.position, Quaternion.identity, transform.parent.parent);
                }
            }
            _spawned = true;
        }
        Destroy(gameObject);
    }
    public bool GetSpawnedBool() {
        return _spawned;
    }
}
