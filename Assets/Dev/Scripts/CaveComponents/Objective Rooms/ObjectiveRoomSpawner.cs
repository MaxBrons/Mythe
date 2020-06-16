using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectiveRoomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _rooms;
    private void Start() {
        Instantiate(_rooms[ObjectiveDoor.RoomToSpawn]);
        GameObject.FindGameObjectWithTag(Constants._navMeshComponents).GetComponent<NavMeshSurface>().BuildNavMesh();
    }
}
