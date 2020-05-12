using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour
{
    private void Start() {
        Destroy(gameObject, 10f);
    }
    private void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject);
    }
}
