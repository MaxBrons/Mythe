using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool SpawnNewLevel { get; set; } = false;
    public int NextToSpawnCaveLevelIndex { get; set; } = 0;
    public int CurrentCaveLevel { get; set; } = 0;

    private void Awake() {
        Instance = this;

        //Save and load a new level seed
        if (!SpawnNewLevel) {
            SpawnNewLevel = true;
            GameSave.SaveLevel();
            GameSave.LoadLevel(CurrentCaveLevel);
        }
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

    public void QuitGame() {
        //Saves the data and closes the aplication
        Application.Quit();
    }

    private void PauzeGame() => Time.timeScale = 0;
    private void ResumeGame() => Time.timeScale = 1;
}
