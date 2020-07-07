using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }
    [SerializeField] private AudioMixer _mixer;

    private void Awake() => Instance = this;

    public void ChangeGlobalVolume(float value) => _mixer.SetFloat(Constants._audioMixerVolume, value);
}
