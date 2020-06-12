using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;

    private void Awake() {
        _animator = GetComponent<Animator>();
    }

    public void SetBool(string name, bool state) => _animator.SetBool(name, state);
    public bool GetBool(string name) { return _animator.GetBool(name); }

    public float GetCurrentClipLenght() {
        return _animator.GetCurrentAnimatorClipInfo(0).Length;
    }
}
