using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnpoint : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemies;
    private void Start() {
        //Spawns an enemy at the object's position, this script is on
        Instantiate(_enemies[Random.Range(0,_enemies.Length)], transform.position, Quaternion.identity);
    }
}
