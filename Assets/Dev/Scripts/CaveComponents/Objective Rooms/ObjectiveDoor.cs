using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveDoor : MonoBehaviour
{
    public static int roomToSpawn;

    [SerializeField] private bool _fromObjectiveRoom;
    private int rand = 0;

    private void Start() {
        if (!_fromObjectiveRoom) rand = Random.Range(0, 2);
    }
    private void OnMouseDown() {
        if (_fromObjectiveRoom) {
            SceneManager.LoadSceneAsync(1);
            return;
        }
        roomToSpawn = rand;
        SceneManager.LoadSceneAsync(2);
    }
}
