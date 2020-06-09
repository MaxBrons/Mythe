using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public InputMaster _inputMaster { get; private set; }

    private void Awake() {
        //Destroys the object if there are more than 1 of
        if (Instance) {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        _inputMaster = new InputMaster();
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeUserInput(bool value) {
        if (value) {
            _inputMaster.Player.Disable();
        }
        else _inputMaster.Player.Enable();
    }
}
