using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sound : MonoBehaviour
{
    private enum SoundType
    {
        Background, Ambient, Once
    }
    [SerializeField] private AudioClip _clip;
    [SerializeField] private SoundType _soundType;
    [SerializeField] private float _waitForNextSound = 120;
    private AudioSource _source;
    private void OnDestroy() => SoundManager.Instance.OnGlobalVolumeChange -= UpdateVolume;
    private void Start() {
        _source = GetComponent<AudioSource>();
        SoundManager.Instance.OnGlobalVolumeChange += UpdateVolume;

        if (_soundType == SoundType.Background) StartCoroutine(PlayRandomRepeatingSound());
        else if (_soundType == SoundType.Ambient) StartCoroutine(PlayRepeatingSound());
        else if (_soundType == SoundType.Once) PlayOnce();
    }

    private void PlayOnce() {
        _source.loop = false;
        _source.clip = _clip;
        _source.Play();
    }

    private IEnumerator PlayRepeatingSound() {
        while (true) {
            _source.clip = _clip;
            _source.Play();
            yield return new WaitForSeconds(_waitForNextSound);
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
    public void UpdateVolume(float value) => _source.volume = value;
    public void SetClip(AudioClip clip) => _clip = clip;
    #endregion
}
