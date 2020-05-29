using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    private const string _spawnpointTag = "Spawnpoint";
    private const string _spawnFunctionName = "Spawn";
    private const string _caveSectionTag = "CaveSections";

    private int rand = 0;
    private bool _spawned = false;

    private CaveSectionTemplate _caveSectionTemplate;

    private void Start() {
        _caveSectionTemplate = GameObject.FindGameObjectWithTag(_caveSectionTag).GetComponent<CaveSectionTemplate>(); //Holds all the differend sections it can spawn

        rand = Random.Range(0, _caveSectionTemplate.GetSpawnableSections().Count); //Sets a random int for the next random cave section to spawn
        Invoke(_spawnFunctionName, 0.5f); //Invokes the method, so that the collision has time to check propperly
        Destroy(gameObject, 30f);
    }
    private void Spawn() {
        //Instantiates the random cave section
        Instantiate(GetSection(), transform.position, Quaternion.Euler(0, transform.rotation.eulerAngles.y + (int)_spawnpointdirection, 0), _caveSectionTemplate.transform);
        _spawned = true;
    }
    private GameObject GetSection() {
        if (_dependecySection) return _dependecySection; //Returns the section the spawnpoint is depending on
        else return _caveSectionTemplate.GetSpawnableSections()[Random.Range(0, rand)]; //Returns a random cave section
    }
    private void OnTriggerEnter(Collider other) {
        //Don't check for collision if not colliding with a Spawnpoint or if this spawnpoint has already spawned a cave section
        if (!other.CompareTag(_spawnpointTag) || _spawned) return; 

        //Spawn an Intersection if it collides with an already spawned cave section
        if(!_caveSectionTemplate) _caveSectionTemplate = GameObject.FindGameObjectWithTag(_caveSectionTag).GetComponent<CaveSectionTemplate>();
        Instantiate(_caveSectionTemplate.GetIntersection(), transform.position, Quaternion.identity, _caveSectionTemplate.transform);
        Destroy(gameObject);
        _spawned = true;
    }
}
