using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveRoom : MonoBehaviour
{
    [SerializeField] private Transform _spawnpoint;
    private void Start() {
        GameManager.Instance.SpawnPlayerAtSpawnpoint(_spawnpoint.position);
    }
}
