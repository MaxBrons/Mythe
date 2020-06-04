using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private bool _destruct = false; //If true, this object will destroy itself on collision
    private const string _closedCaveSection = "IntersectionCaveSection";
    private void Start() {
        // Destroys the script or the entire object depending on if the script is set to destruct or not
        if (!_destruct) Destroy(gameObject, 10f);
        else Destroy(this, 5f);
    }

    //Destroys eather the object itself or the object it collides with
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(_closedCaveSection)) return;
        if (_destruct) {
            Destroy(gameObject);
            return;
        }
        Destroy(other.gameObject);
    }
}
