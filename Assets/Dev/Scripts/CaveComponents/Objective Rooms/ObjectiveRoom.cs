using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveRoom : MonoBehaviour
{
    [SerializeField] private Transform _spawnpoint;
    private void Start() {
        GameObject.FindGameObjectWithTag(Constants._mainPlayer).transform.localPosition = Vector3.zero;
        GameObject.FindGameObjectWithTag(Constants._player).transform.position = _spawnpoint.position;
    }
}
