using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePileOfBodies : MonoBehaviour
{
    [SerializeField] GameObject _particles;
    private void OnMouseDown() {
        //Get the distance from the pile of bodies to the player
        float distance = Vector3.Distance(transform.position, Player.Instance.transform.GetChild(0).transform.position);
        if (distance < 5) {
            Instantiate(_particles, transform.position, transform.rotation); //Spawn the particle system
            _particles.GetComponent<ParticleSystem>().Play(); //Start the particle system
            ObjectiveManager.Instance.AddClearedObjectiveRoom(); //Add the room to the cleared room list
            Destroy(this); //Destroy this script
        }
    }
}
