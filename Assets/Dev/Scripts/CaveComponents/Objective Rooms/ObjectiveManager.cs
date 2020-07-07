using JetBrains.Annotations;
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
    public List<ObjectiveDoor> AllObjectiveDoors { get; private set; } = new List<ObjectiveDoor>();

    private void Awake() {
        Instance = Instance ? Instance : this;
    }

    private void UpdateClearedObjectives() {
        if (ClearedObjectiveRooms.Count < 1) return;
        StartCoroutine(FindDoors());
        AllObjectiveDoors.Clear();
    }

    private IEnumerator FindDoors() {
        //Find every door in the list and apply the fire effect to them
        yield return new WaitForSeconds(.1f);
        if (ClearedObjectiveRooms.Count == AllObjectiveDoors.Count) LevelLoader.Instance.LoadLevel(5);
        foreach (Vector3 pos in ClearedObjectiveRooms) {
            Collider door = Physics.OverlapSphere(pos, 10f, 1 << 13)[0];
            if (!door || door.transform.position != pos) yield break;
            door.GetComponent<ObjectiveDoor>().SetDoorClearedUIActiveState(true);
        }
    }

    public void TryUpdateClearedRooms() {
        if (!_playerCameFromObjectiveRoom) return;

        //Set the player back to the objective door entry point in the cave system
        UpdateClearedObjectives();
        Player.Instance.SpawnAtLastEnteredDoorPosition();
        _playerCameFromObjectiveRoom = false;
    }
    public void AddClearedObjectiveRoom() {
        ClearedObjectiveRooms.Add(LastEnteredDoorPosition);
    }
    public void SetClosestDoor(ObjectiveDoor door) {
        _closestDoor = door;
    }
}
