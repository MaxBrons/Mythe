using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }
    public event Action<float> OnGlobalVolumeChange;

    private void Awake() => Instance = this;

    public void ChangeGlobalVolume(float value) {
        OnGlobalVolumeChange?.Invoke(value);
    }
}
