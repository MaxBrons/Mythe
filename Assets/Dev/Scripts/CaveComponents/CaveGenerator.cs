using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CaveGenerator : MonoBehaviour
{
    public static CaveGenerator Instance;
    private List<CaveSectionData> _caveData = new List<CaveSectionData>();
    private string path; 

    private void Awake() => Instance = Instance ? Instance : this;
    private void Start() {
        path = Application.persistentDataPath + Constants._caveSaveLocation + Constants._caveName + GameSave._randomSeed + GameManager.Instance.CurrentCaveLevel + Constants._saveLocationFileDataType;
        StartCoroutine(GenerateCave());
    }
    public IEnumerator GenerateCave() {
        if (!File.Exists(path)) {
            yield return new WaitForSeconds(5f);

            //Save the generated Cave to a file
            GameSave.SaveLevel(_caveData, Constants._caveName, GameManager.Instance.CurrentCaveLevel);
            Debug.Log("Level Generated");
        }
        LevelLoader.Instance.LoadLevel(2);
    }

    public void AddCaveData(CaveSectionData data) {
        _caveData.Add(data);
    }

    public void RetryCaveSpawning() {
        if (File.Exists(path)) {
            File.Delete(path);
            LevelLoader.Instance.LoadLevel(1);
            Debug.Log("Level Deleted, creating a new one...");
        }
    }
}
