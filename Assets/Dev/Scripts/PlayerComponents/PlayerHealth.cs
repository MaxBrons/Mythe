using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _health = 100;
    [SerializeField] private GameObject _bag;
    private EventHandler _eventHandler;

    private void Start() {
        _eventHandler = EventHandler.Instance;
    }
    public void Damage(float amount) {
        //(3f - (_health * (_health / 10000)))/10;  for vignette effect
        if (_health <= 0) {
            SpawnBag();
            LevelLoader.Instance.LoadLevel(0);
            return;
        }
        _eventHandler.DamagePlayer();
        _eventHandler.PlayerMadeNoice(transform.position);
        _health -= amount;
    }

    private void SpawnBag()
    {
        Inventory inv = GameObject.FindGameObjectWithTag(Constants._mainPlayer).GetComponent<Inventory>();
        _bag.GetComponent<Inventory>().Equals(inv);
        Instantiate(_bag, transform.position, Quaternion.identity);
        inv.Clear();
    }
}
