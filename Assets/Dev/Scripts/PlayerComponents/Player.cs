using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public InputMaster _inputMaster { get; private set; }
    public Vector3 LastSpawnpointPosition { get; set; }

    //Destroys the object if there are more than 1 of
    private void Awake() {
        Instance = Instance ? Instance : this;
        _inputMaster = new InputMaster();
    }

    private void Start() {
        if (Instance != this) {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
    public void ChangeUserInput(bool value) {
        if (value) _inputMaster.Player.Disable();
        else _inputMaster.Player.Enable();
    }

    public void SetPosition(Vector3 pos) {
        transform.position = pos;
        transform.GetChild(1).transform.localPosition = Vector3.zero;
    }

    public void SetLastEnteredDoorPosition() => LastSpawnpointPosition = transform.GetChild(1).position;
    public void SpawnAtLastEnteredDoorPosition() => SetPosition(LastSpawnpointPosition);
}
