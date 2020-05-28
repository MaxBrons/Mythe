using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public event Action OnPlayerDamage;
    public event Action<Vector3> OnPlayerMakingNoice;

    public void DamagePlayer() => OnPlayerDamage?.Invoke();
    public void PlayerMadeNoice(Vector3 target) => OnPlayerMakingNoice?.Invoke(target);
}
