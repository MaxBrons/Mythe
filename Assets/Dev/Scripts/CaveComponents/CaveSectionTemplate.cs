using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CaveSectionTemplate : MonoBehaviour
{
    /// <summary>
    /// Holds the objects/ cave sections that can be spawned by the spawnpoints
    /// </summary>
    [SerializeField] private List<GameObject> _caveSections;
    [SerializeField] private GameObject _closedSection;
    [SerializeField] private GameObject _intersection;

    private void Start() => Invoke("UpdateNavMesh", 10f);

    private void UpdateNavMesh(){}

    #region Getters & Setters
    public List<GameObject> GetSpawnableSections() {
        return _caveSections;
    }
    public GameObject GetClosedSection() {
        return _closedSection;
    }
    public GameObject GetIntersection() {
        return _intersection;
    }
    #endregion
}
