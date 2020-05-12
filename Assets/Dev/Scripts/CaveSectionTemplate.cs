using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveSectionTemplate : MonoBehaviour
{
    [SerializeField] private GameObject[] _frontCaveSections;
    [SerializeField] private GameObject[] _backCaveSections;
    [SerializeField] private GameObject[] _rightCaveSections;
    [SerializeField] private GameObject[] _leftCaveSections;
    [SerializeField] private GameObject _closedSection;
    [SerializeField] private GameObject _intersection;

    private Dictionary<int, GameObject[]> _spawnabelSections = new Dictionary<int, GameObject[]>();
    private void Awake() {
        AddSectionsToDictionaries();
    }
    private void AddSectionsToDictionaries() {
        _spawnabelSections.Add(0, _frontCaveSections);
        _spawnabelSections.Add(1, _backCaveSections);
        _spawnabelSections.Add(2, _leftCaveSections);
        _spawnabelSections.Add(3, _rightCaveSections);
    }

    public GameObject[] GetSpawnableSections(int i) {
        return _spawnabelSections[i];
    }
    public GameObject GetClosedSection() {
        return _closedSection;
    }
    public GameObject GetIntersection() {
        return _intersection;
    }
}
