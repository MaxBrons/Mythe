using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class UI_Menu_Screen : MonoBehaviour
{
    [SerializeField] private int _sceneIndex;
    private InputMaster _interaction;

    private void Awake() {
        _interaction = Player.Instance && Player.Instance._inputMaster != null ? Player.Instance._inputMaster : new InputMaster();
        _interaction.Player.Interact.performed += ctx => GoToScene();
        _interaction.Player.Interact.Enable();
        _interaction.UserInterface.Disable();

        //Turns off/ on the lock on the cursor and makes it visible/invisible
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private void GoToScene() {
        _interaction.Player.Interact.performed -= ctx => GoToScene();
        _interaction.UserInterface.Enable();

        //Turns off/ on the lock on the cursor and makes it visible/invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        LevelLoader.Instance.LoadLevel(_sceneIndex);
    }
}
