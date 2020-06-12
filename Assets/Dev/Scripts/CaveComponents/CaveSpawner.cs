using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class CaveSpawner : MonoBehaviour
{
    public void Start() {
        //Store the fetched cave sections
        List<CaveSectionData> data = GameSave.LoadLevel(GameManager.Instance.CurrentCaveLevel);

        //Delete the files if there are no cave sections to spawn
        if (data == null) {
            GameSave.DeleteFile(GameManager.Instance.CurrentCaveLevel);
            LevelLoader.Instance.LoadLevel(1);
            Debug.LogError("Data is null");
            return;
        }

        //Delete the save file of the current level and generate a new one
        if (data == null || data.Count < 1) {
            CaveGenerator.Instance.RetryCaveSpawning();
            return;
        }

        //Spawn all cave sections
        for(int i = 0; i < data.Count; i++) {
            GameObject obj = Instantiate(GetComponent<CaveSectionTemplate>().GetCaveSectionsTypes()[data[i]._caveSectionType], transform);
            obj.transform.position = new Vector3(data[i]._position[0], data[i]._position[1], data[i]._position[2]);
            obj.transform.eulerAngles = new Vector3(data[i]._rotation[0], data[i]._rotation[1], data[i]._rotation[2]);
        }
        GameObject.FindGameObjectWithTag(Constants._navMeshComponents).GetComponent<NavMeshSurface>().BuildNavMesh();
    }
}
