using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveDoor : MonoBehaviour
{
    public static int roomToSpawn;
    public bool _isCleared { get; set; } = false;

    [SerializeField] private bool _fromObjectiveRoom;
    [SerializeField] private bool _fromStartToMainScene = false;
    [SerializeField] private GameObject _playerSpawnpoint;
    private int rand = 0;

    private void Start() {
        rand = !_fromObjectiveRoom ? Random.Range(0, 3) : 0; //Pick a random room
        transform.GetChild(0).GetComponent<Canvas>().worldCamera = Camera.main;
    }
    private void OnMouseDown() => OpenDoor();
    public void OpenDoor() {
        if (_isCleared) return; //Check if the room is already cleared

        //Set the player spawnpoint to the PlayerSpawnpoint's position if you come from the Starting room
        SetPlayerSpawnpoint();

        //Swith to the main scene and spawn the player at the appropriate position
        if (_fromObjectiveRoom || _fromStartToMainScene) {
            LevelLoader.Instance.LoadLevel(3);
            return;
        }
        //Spawns the objective room
        SpawnRandomObjectiveRoom();
    }

    private void SpawnRandomObjectiveRoom() {
        //Go to a random objective room
        roomToSpawn = rand;
        LevelLoader.Instance.LoadLevel(4);
        ObjectiveRoom.Instance.LastEnteredDoor = this;
    }

    private void SetPlayerSpawnpoint() {
        if (_fromObjectiveRoom) return;

        //Sets the players return point
        if (_fromStartToMainScene) {
            Player.Instance.LastSpawnpointPosition = _playerSpawnpoint.transform.position;
            return;
        }
        //Save the players position
        Player.Instance.LastSpawnpointPosition = Player.Instance.transform.GetChild(0).position;
        Debug.Log(Player.Instance.LastSpawnpointPosition);
    }
}
