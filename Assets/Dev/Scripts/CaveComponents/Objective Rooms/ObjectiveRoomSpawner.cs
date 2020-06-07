using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveRoomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _rooms;
    private void Start() {
        Instantiate(_rooms[ObjectiveDoor.roomToSpawn]);
    }
}
