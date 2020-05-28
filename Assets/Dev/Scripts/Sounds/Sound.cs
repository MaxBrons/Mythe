using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sound : MonoBehaviour
{
    private enum SoundType
    {
        Background, Ambient
    }
    [SerializeField] private AudioClip _clip;
    [SerializeField] private SoundType _soundType;
    [SerializeField] private float _waitForNextSound = 120;
    private AudioSource _source;

    private void Awake() {
        _source = GetComponent<AudioSource>();
    }

    private void Start() {
        if (_soundType == SoundType.Background) StartCoroutine(PlayRandomRepeatingSound());
        else if (_soundType == SoundType.Ambient) StartCoroutine(PlayRepeatingSound());
    }

    private IEnumerator PlayRepeatingSound() {
        while (true) {
            _source.clip = _clip;
            _source.Play();
            yield return new WaitForSecondsRealtime(_waitForNextSound);
        }
    }

    private IEnumerator PlayRandomRepeatingSound() {
        if (!_clip) SetRandomAudioClip();
        while (true) {
            _source.clip = _clip;
            _source.Play();
            yield return new WaitUntil(() => !_source.isPlaying);
            SetRandomAudioClip();
        }
    }

    private void SetRandomAudioClip() {
        AudioClip[] audioclips = GetComponent<SoundTemplate>().GetSoundClip();
        _clip = audioclips[Random.Range(0, audioclips.Length)];
    }



    #region Getters & Setters
    public void SetPitch(float value) => _source.pitch = value;
    public void SetVolume(float value) => _source.volume = value;
    public void SetClip(AudioClip clip) => _clip = clip;
    #endregion


}
