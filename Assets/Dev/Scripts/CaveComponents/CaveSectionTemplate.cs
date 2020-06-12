using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CaveSectionTemplate : MonoBehaviour
{
    /// <summary>
    /// Holds the objects/ cave sections that can be spawned by the spawnpoints
    /// </summary>

    [SerializeField] private List<GameObject> _caveSections;
    [SerializeField] private List<GameObject> _caveSectionTypes;
    [SerializeField] private GameObject _intersection;

    public static CaveSectionTemplate Instance;
    private void Awake() {
        Instance = this;
    }

    #region Getters & Setters
    public List<GameObject> GetSpawnableSections() {
        return _caveSections;
    }
    public List<GameObject> GetCaveSectionsTypes() {
        return _caveSectionTypes;
    }
    public GameObject GetIntersection() {
        return _intersection;
    }
    #endregion
}
