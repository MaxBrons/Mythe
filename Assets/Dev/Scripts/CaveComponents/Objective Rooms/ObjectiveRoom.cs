using System.Collections;
using UnityEngine;

public class ObjectiveRoom : MonoBehaviour
{
    [SerializeField] private Transform _spawnpoint;
    [SerializeField] private Transform _fromStartSpawnpoint;

    private void Start() {
        if (CheckIfCameFromStart()) return;

        ObjectiveManager.Instance.TryUpdateClearedRooms();

        //Spawn the player at the spawnpoint position
        if (!_spawnpoint) return;
        Player.Instance.SetPosition(_spawnpoint.transform.position);
    }

    private bool CheckIfCameFromStart() {
        //Spawn the player at beginning of first level
        if (ObjectiveManager.Instance._spawnPlayerFromSpawn) {
            Player.Instance.SetPosition(_fromStartSpawnpoint.transform.position);
            ObjectiveManager.Instance._spawnPlayerFromSpawn = false;
            return true;
        }
        return false;
    }
}
