using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CaveSectionSpawnpoint : MonoBehaviour
{
    //The enum is for the offset of the rotation from the object
    public enum sectionopeningdirections
    {
        front = 0,
        back = 180,
        left = -90,
        right = 90
    }

    [SerializeField] private sectionopeningdirections _spawnpointdirection = sectionopeningdirections.front; //Offset of the object's rotation on instantiation
    [SerializeField] private GameObject _dependecySection = null; //This object will always spawn instead of a random one if it's not null

    private int rand = 0;
    private bool _spawned = false;

    private void Start() {
        //Gets a random Cave Section to spawn
        rand = Random.Range(0, CaveSectionTemplate.Instance.GetSpawnableSections().Count); //Sets a random int for the next random cave section to spawn
        Invoke(Constants._spawnFunctionName, 0.5f); //Invokes the method, so that the collision has time to check propperly
        Destroy(gameObject, 30f);
    }
    private void Spawn() {
        //Instantiates the random cave section
        Instantiate(GetSection(), transform.position, Quaternion.Euler(0, transform.rotation.eulerAngles.y + (int)_spawnpointdirection, 0), CaveSectionTemplate.Instance.transform);
        GameObject.FindGameObjectWithTag(Constants._navMeshComponents).GetComponent<NavMeshSurface>().BuildNavMesh();
        _spawned = true;
    }
    private GameObject GetSection() {
        if (_dependecySection) return _dependecySection; //Returns the section the spawnpoint is depending on
        else return CaveSectionTemplate.Instance.GetSpawnableSections()[Random.Range(0, rand)]; //Returns a random cave section
    }
    private void OnTriggerEnter(Collider other) {
        //Don't check for collision if not colliding with a Spawnpoint or if this spawnpoint has already spawned a cave section
        if (!other.CompareTag(Constants._spawnpointTag) || _spawned) return;

        //Spawn an Intersection if it collides with an already spawned cave section
        Instantiate(CaveSectionTemplate.Instance.GetIntersection(), transform.position, Quaternion.identity, CaveSectionTemplate.Instance.transform);
        GameObject.FindGameObjectWithTag(Constants._navMeshComponents).GetComponent<NavMeshSurface>().BuildNavMesh();

        Destroy(gameObject);
        _spawned = true;
    }
}
