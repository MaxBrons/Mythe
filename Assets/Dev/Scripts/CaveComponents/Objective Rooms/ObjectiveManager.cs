using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public static ObjectiveManager Instance;
    public ObjectiveDoor _closestDoor { get; private set; }
    public bool _spawnPlayerFromSpawn { get; set; }
    public bool _playerCameFromObjectiveRoom { get; set; }
    public Vector3 LastEnteredDoorPosition { private get; set; }
    private List<Vector3> ClearedObjectiveRooms = new List<Vector3>();

    private void Awake() {
        Instance = Instance ? Instance : this;
    }

    private void UpdateClearedObjectives() {
        if (ClearedObjectiveRooms.Count < 1) return;
        StartCoroutine(FindDoors());
    }

    private IEnumerator FindDoors() {
        yield return new WaitForSeconds(.05f);

        foreach (Vector3 pos in ClearedObjectiveRooms) {
            Collider door = Physics.OverlapSphere(pos, 10f, 1 << 13)[0];
            if (!door || door.transform.position != pos) yield break;
            door.GetComponent<ObjectiveDoor>().SetDoorClearedUIActiveState(true);
        }
    }

    public void TryUpdateClearedRooms() {
        if (!_playerCameFromObjectiveRoom) return;
        UpdateClearedObjectives();
        _playerCameFromObjectiveRoom = false;
    }
    public void AddClearedObjectiveRoom() {
        ClearedObjectiveRooms.Add(LastEnteredDoorPosition);
    }
    public void SetClosestDoor(ObjectiveDoor door) {
        _closestDoor = door;
    }
}
