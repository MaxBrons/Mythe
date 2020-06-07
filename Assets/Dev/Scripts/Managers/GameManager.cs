using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static bool SpawnNewLevel = false;
    public static int NextToSpawnCaveLevelIndex = 0;
    public static int CurrentCaveLevel = 0;

    private void Awake() {
        Instance = this;
        if (!SpawnNewLevel) {
            SpawnNewLevel = true;
            SaveSystem.NewLevel();
        }
    }
}
