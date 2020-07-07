using UnityEngine;
using System.Collections;

public class Annie_Health : MonoBehaviour
{

    [SerializeField] private float _health = 500;
    [SerializeField] private GameObject _massiveParticle;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private Animator _fadeScreen;

    //Damages Annie
    public void TakeDamage(float amount) {
        if (_health <= 0) {
            Instantiate(_massiveParticle, transform.position, _massiveParticle.transform.rotation);
            Destroy(gameObject, 2f);
            LevelLoader.Instance.LoadLevel(6);
            return;
        }
        _health -= amount;
    }
}
