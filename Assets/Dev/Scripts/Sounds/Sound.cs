using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sound : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private bool _ambient = false;
    [SerializeField] private float _waitForNextAmbientSound = 120;
    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (!_ambient) StartCoroutine("PlaySound");
        else
        {
            IEnumerator ambient = PlaySound(_waitForNextAmbientSound);
            StartCoroutine(ambient);
        }
    }

    private IEnumerator PlaySound(float time)
    {
        while (true)
        {
            new WaitForSeconds(time);
            _source.clip = _clip;
            _source.Play();
        }
    }

    private IEnumerator PlayRepeatingSound()
    {
        while (true)
        {
            if (!_clip) break;
            _source.clip = _clip;
            _source.Play();
            yield return new WaitUntil(() => !_source.isPlaying);

            AudioClip[] audioclips = GetComponent<SoundTemplate>().GetSoundClip();
            _clip = audioclips[Random.Range(0, audioclips.Length)];
        }
    }



    #region Getters & Setters
    public void SetPitch(float value) => _source.pitch = value;
    public void SetVolume(float value) => _source.volume = value;
    public void SetClip(AudioClip clip) => _clip = clip;
    #endregion


}
