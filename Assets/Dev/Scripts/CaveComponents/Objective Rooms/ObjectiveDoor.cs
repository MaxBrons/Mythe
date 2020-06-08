using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveDoor : MonoBehaviour
{
    public static int roomToSpawn;
    public static Vector3 lastPosition;

    [SerializeField] private bool _fromObjectiveRoom;
    [SerializeField] private bool _fromStartToMainScene = false;
    private int rand = 0;

    private void Start() {
        if (!_fromObjectiveRoom) rand = Random.Range(0, 3);
    }
    private void OnMouseDown() {
        if (_fromObjectiveRoom) {
            LevelLoader.Instance.LoadLevel(1);
            GameManager.Instance.SpawnPlayerAtSpawnpoint(new Vector3(0, 13, 28));
            //else GameManager.Instance.SpawnPlayerAtSpawnpoint(lastPosition);
            return;
        }
        //lastPosition = transform.position + new Vector3(0, 3, -1);
        roomToSpawn = rand;
        LevelLoader.Instance.LoadLevel(2);
    }
}
