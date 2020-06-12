using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public InputMaster _inputMaster { get; private set; }
    public Vector3 LastSpawnpointPosition { get; set; }

    private void Awake() {
        //Destroys the object if there are more than 1 of
        Instance = Instance ? Instance : this;
        if (Instance != this) {
            Destroy(gameObject);
            return;
        }

        _inputMaster = new InputMaster();
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeUserInput(bool value) {
        if (value) _inputMaster.Player.Disable();
        else _inputMaster.Player.Enable();
    }
}
