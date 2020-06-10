using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnpoint : MonoBehaviour
{
    [SerializeField] private GameObject _enemyToSpawn;
    private void Start() {
        //Spawns an enemy at the object's position, this script is on
        Instantiate(_enemyToSpawn, transform.position, Quaternion.identity);
    }
}
