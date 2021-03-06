﻿using UnityEngine;
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
        if (_health <= 0) {
            SpawnBag();
            ResetPlayer();
            LevelLoader.Instance.LoadLevel(7);
            return;
        }
        _eventHandler.DamagePlayer();
        _eventHandler.PlayerMadeNoice(transform.position);
        _health -= amount;
    }

    private void SpawnBag()
    {
        Inventory inv = GetComponent<Inventory>();
        _bag.GetComponent<Inventory>().Equals(inv);
        Instantiate(_bag, transform.position, Quaternion.identity);
        inv.Clear();
    }

    public void ResetPlayer() {
        GetComponent<PlayerUI>().ResetVignette();
        _health = 100;
    }

    public float GetHealth() { return _health; }
}
