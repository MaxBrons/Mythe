using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public static EventHandler Instance;
    public event Action OnPlayerDamage;
    public event Action<Vector3> OnPlayerMakingNoice;

    private void Awake() => Instance = this;
    public void DamagePlayer() => OnPlayerDamage?.Invoke();
    public void PlayerMadeNoice(Vector3 target) => OnPlayerMakingNoice?.Invoke(target);
}
