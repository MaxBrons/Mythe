using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _menuScreensObject;
    [SerializeField] private GameObject[] _menuObjects;
    private GameObject _currentMenu;
    private InputMaster _inputMaster;
    private bool _menuOpened = false;
    private bool _invOpen = false;

    private void Start() {
        //Sets the values of the input to the corresponding stored variables
        _inputMaster = Player.Instance && Player.Instance._inputMaster != null ? Player.Instance._inputMaster : new InputMaster();
        _inputMaster.UserInterface.Esc.Enable();
        _inputMaster.UserInterface.Esc.performed += ctx => OnEscPressed();
        _inputMaster.UserInterface.Tab.Enable();
        _inputMaster.UserInterface.Tab.performed += ctx => OnTabPressed();
    }
    private void OnApplicationFocus(bool focus) {
        //Open pauze menu automaticly when out of focus
        if (!focus && !_menuOpened) OnEscPressed();
    }

    private void OnEscPressed() {
        if (_invOpen) return;

        //Close the previous window if there was one open
        if (_currentMenu) {
            CloseMenu();
            return;
        }

        //Pauze the rest of the game
        GameManager.Instance.CheckToPauzeGame(!_menuOpened);

        //Open the Pauze screen
        _menuOpened = !_menuOpened;
        _menuScreensObject.SetActive(_menuOpened);

        //Change the user's control scheme and show/ hide the cursor
        Player.Instance.ChangeUserInput(_menuScreensObject.activeSelf);
        SwitchCursorVisible();
    }

    private void OnTabPressed() {
        if (_menuOpened) return;
        _menuObjects[1].SetActive(!_menuObjects[1].activeSelf);
    }

    private void SwitchCursorVisible() {
        //Turns off/ on the lock on the cursor and makes it visible/invisible
        Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = !Cursor.visible;
    }

    private void CloseMenu() {
        //This will close the opened menu
        _menuScreensObject.SetActive(true);
        _currentMenu.SetActive(false);
        _currentMenu = null;
    }

    public void UpdateCurrentMenu(int menu) {
        //Set the current menu to the new menu and close the previous menu
        if (_currentMenu != null) _currentMenu.SetActive(false);

        _currentMenu = _menuObjects[menu];
        _menuObjects[menu].SetActive(true);
        _menuScreensObject.SetActive(false);
    }

    public void GoToScene(int index) {
        OnEscPressed();
        SwitchCursorVisible();
        LevelLoader.Instance.LoadLevel(index);
    }
}
