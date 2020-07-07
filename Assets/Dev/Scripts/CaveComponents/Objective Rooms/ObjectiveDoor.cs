using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveDoor : MonoBehaviour
{
    public static int RoomToSpawn;
    [SerializeField] private GameObject _doorUI;
    [SerializeField] private GameObject _doorClearedUI;
    [SerializeField] private bool _fromStartingRoom = false;
    [SerializeField] private bool _fromObjectiveRoom = false;
    private InputMaster _interaction;
    private int _rand;

    private void Awake() {
        _interaction = Player.Instance && Player.Instance._inputMaster != null ? Player.Instance._inputMaster : new InputMaster();
        _interaction.Player.Interact.performed += ctx => OnInputButtonPressed();
        _interaction.Player.Interact.Enable();
        _rand = Random.Range(0, 3);
    }

    private void SetPlayerSpawnpoint() {
        //Save the players position
        if (_fromStartingRoom || _fromObjectiveRoom) return;
        Player.Instance.SetLastEnteredDoorPosition();
        ObjectiveManager.Instance.LastEnteredDoorPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other) {
        if (_doorClearedUI && _doorClearedUI.activeSelf) return;

        //Shows the UI when in range
        ObjectiveManager.Instance.SetClosestDoor(this);
        SetDoorUIActiveState(true);
    }
    private void OnTriggerExit(Collider other) {
        if (_doorClearedUI && _doorClearedUI.activeSelf) return;

        //Stops showing the UI when out of range
        ObjectiveManager.Instance.SetClosestDoor(null);
        SetDoorUIActiveState(false);
    }

    private void OnInputButtonPressed() {
        if (!_doorUI || !_doorUI.activeSelf) return;
        SetPlayerSpawnpoint();

        //Disable player movement
        GameObject.FindGameObjectWithTag(Constants._mainPlayer).GetComponent<PlayerMovement>().enabled = false;
        
        //Sets the players spawnposition to the first level spawnpoint if the player came from the start room
        ObjectiveManager.Instance.SetClosestDoor(null);
        if (_fromStartingRoom) ObjectiveManager.Instance._spawnPlayerFromSpawn = true;

        //Go to the set scene based on some variables
        int levelToSpawn = _fromStartingRoom || _fromObjectiveRoom ? 3 : 4;
        LoadRoom(levelToSpawn);

        //Set the player's position to the stored position from before entering the objective room
        if (_fromObjectiveRoom) {
            ObjectiveManager.Instance._playerCameFromObjectiveRoom = true;
        }

        //Enable player movement
        GameObject.FindGameObjectWithTag(Constants._mainPlayer).GetComponent<PlayerMovement>().enabled = true;
    }
    private void LoadRoom(int roomInt) {
        //Go to a random objective room
        RoomToSpawn = _rand;
        LevelLoader.Instance.LoadLevel(roomInt);
    }

    private void SetDoorUIActiveState(bool state) => _doorUI.SetActive(_doorUI ? state : false);
    public void SetDoorClearedUIActiveState(bool state) {
        _doorClearedUI.SetActive(_doorClearedUI ? state : false);
        SetDoorUIActiveState(false);
        Destroy(this);
    }
}
