using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTemplate : MonoBehaviour
{

    [Header(Constants._soundHeader)]
    [SerializeField] private AudioClip[] _soundClips;

    public AudioClip[] GetSoundClip()
    {
        return _soundClips;
    }
}
