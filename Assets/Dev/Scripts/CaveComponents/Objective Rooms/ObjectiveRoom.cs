using System.Collections;
using UnityEngine;

public class ObjectiveRoom : MonoBehaviour
{
    [SerializeField] private Transform _spawnpoint;
    [SerializeField] private Transform _fromStartSpawnpoint;

    private void Start() {
        StartCoroutine(CheckIfCameFromStart());
        if (_fromStartSpawnpoint) return;

        ObjectiveManager.Instance.TryUpdateClearedRooms();

        //Spawn the player at the spawnpoint position
        if (!_spawnpoint) return;
        Player.Instance.SetPosition(_spawnpoint.transform.position);
    }

    private IEnumerator CheckIfCameFromStart() {
        //Spawn the player at beginning of first level
        if (ObjectiveManager.Instance._spawnPlayerFromSpawn) {
            yield return new WaitForSeconds(.5f);
            Player.Instance.SetPosition(_fromStartSpawnpoint.transform.position);
            ObjectiveManager.Instance._spawnPlayerFromSpawn = false;
        }
    }
}
