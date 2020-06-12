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

    private void Start() {
        //Sets the values of the input to the corresponding stored variables
        _inputMaster = Player.Instance._inputMaster;
        _inputMaster.UserInterface.Esc.Enable();
        _inputMaster.UserInterface.Esc.performed += ctx => OnEscPressed();

        //Hide the cursor when the game first starts
        SwitchCursorVisible();
    }
    private void OnApplicationFocus(bool focus) {
        if(!focus && !_menuOpened) OnEscPressed();
    }

    private void OnEscPressed() {
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

    private void SwitchCursorVisible() {
        //Turns off/ on the lock on the cursor and makes it visible/invisible
        Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = !Cursor.visible;
    }

    private void CloseMenu() {
        //This will close the opened menu
        _currentMenu.SetActive(false);
        _currentMenu = null;
    }

    public void UpdateCurrentMenu(int menu) {
        //Set the current menu to the new menu and close the previous menu
        if (_currentMenu != null) _currentMenu.SetActive(false);
        _currentMenu = _menuObjects[menu];
        _menuObjects[menu].SetActive(true);
    }
}
