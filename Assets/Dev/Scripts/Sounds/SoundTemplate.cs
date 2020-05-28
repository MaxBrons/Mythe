using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTemplate : MonoBehaviour
{

    [Header("Sounds")]
    [SerializeField] private AudioClip[] _soundClips;

    public AudioClip[] GetSoundClip()
    {
        return _soundClips;
    }
}
