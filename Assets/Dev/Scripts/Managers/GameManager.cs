using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool SpawnNewLevel = false;
    public int NextToSpawnCaveLevelIndex = 0;
    public int CurrentCaveLevel = 0;

    private void Awake() {
        Instance = this;
        if (!SpawnNewLevel) {
            SpawnNewLevel = true;
            GameSave.SaveLevel();
            GameSave.LoadLevel(CurrentCaveLevel);
        }
    }

    public void SpawnPlayerAtSpawnpoint(Vector3 pos) {
        GameObject.FindGameObjectWithTag(Constants._mainPlayer).transform.localPosition = Vector3.zero;
        GameObject.FindGameObjectWithTag(Constants._player).transform.position = pos;
    }
}
