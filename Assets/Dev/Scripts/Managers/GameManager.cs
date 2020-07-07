using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int CurrentCaveLevel { get; set; } = 0;

    private void Awake() {
        Instance = Instance ? Instance : this;
        GameSave.LoadSeed(CurrentCaveLevel);
    }
    public void SpawnPlayerAtSpawnpoint(Vector3 pos) {
        //Teleports the player to the given position
        GameObject.FindGameObjectWithTag(Constants._mainPlayer).transform.localPosition = Vector3.zero;
        Player.Instance.transform.localPosition = pos;
    }

    public void CheckToPauzeGame(bool value) {
        //Pauze/resume the rest of the game
        if (value) PauzeGame();
        else ResumeGame();
    }
    public void PlayGame() {
        SceneManager.LoadScene(1);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void QuitGame() {
        //Saves the data and closes the aplication
        Application.Quit();
    }

    private void PauzeGame() => Time.timeScale = 0;
    private void ResumeGame() => Time.timeScale = 1;
}
