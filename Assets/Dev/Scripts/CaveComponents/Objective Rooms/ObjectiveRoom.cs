using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveRoom : MonoBehaviour
{
    public static ObjectiveRoom Instance;

    public static Vector3 _initSpawnPosition;
    public ObjectiveDoor LastEnteredDoor { get; set; }

    [SerializeField] private Transform _spawnpoint;
    [SerializeField] private bool _mainSceneRoom = false;

    private void Awake() {
        Instance = this;
        if (_mainSceneRoom) {
            GameManager.Instance.SpawnPlayerAtSpawnpoint(Player.Instance.LastSpawnpointPosition);
            return;
        }
        GameManager.Instance.SpawnPlayerAtSpawnpoint(_spawnpoint.position);
    }

    public void SetObjectiveOnFire() {
        LastEnteredDoor._isCleared = true;
    }
}
