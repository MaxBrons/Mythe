using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sound : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private bool _loop = false;
    [SerializeField] private bool _random = false;
    [SerializeField] private bool _civilian = false;
    [SerializeField] private float _waitForNextSound = 120;
    private AudioSource _source;

    private void Start() {
        //Set the start values of the Audio Source
        _source = GetComponent<AudioSource>();
        _source.volume = Settings._globalVolume;

        //Plays the audio according to the set variables
        StartCoroutine(Play(_loop, _waitForNextSound, _random));
    }

    private IEnumerator Play(bool loop, float seconds = 0, bool random = false) {
        //Set a random pitch for the civilian caughing sound
        if(_civilian) _source.pitch = Random.Range(0.75f, 0.95f);

        //Plays the audio once, repeatedly with a delay or repeatedly
        while (true) {
            if (!loop || !_source.enabled) break; //Breaks the loop if the clip is not supposed to loop

            _source.clip = random ? GetRandomAudioClip() : _clip; //Sets the clip
            _source.Play(); //Plays the clip
            yield return new WaitUntil(() => !_source.isPlaying); //waits until the clip is done playing
            yield return new WaitForSeconds(seconds); //Waits for a set amount of seconds
        }
    }

    private AudioClip GetRandomAudioClip() {
        //Returns a random audio clip
        AudioClip[] audioclips = GetComponent<SoundTemplate>().GetSoundClip();
        _clip = audioclips[Random.Range(0, audioclips.Length)];
        return _clip;
    }

    #region Getters & Setters
    public void SetPitch(float value) => _source.pitch = value;
    public void UpdateVolume(float value) => _source.volume = value;
    public void SetClip(AudioClip clip) => _clip = clip;
    #endregion
}
