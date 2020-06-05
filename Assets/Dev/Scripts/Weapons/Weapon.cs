using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    /// <summary>
    /// Stores the variables of the weapon and has corresponding Getters
    /// </summary>
    
    [SerializeField] private float _damage = 1;
    [SerializeField] private float _range = 1;

    public float GetWeaponDamage() { return _damage; }
    public float GetWeaponRange() { return _range; }
}
