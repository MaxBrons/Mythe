using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerUI : MonoBehaviour
{
    private PlayerHealth _healht;
    private Vignette _vignette;
    private PostProcessVolume _volume;

    private void OnDestroy() => EventHandler.Instance.OnPlayerDamage -= OnPlayerTakeDamage;
    private void Start() {
        _healht = GetComponent<PlayerHealth>();
        _volume = GameObject.FindGameObjectWithTag(Constants._postProcessingTag).GetComponent<PostProcessVolume>();
        _volume.profile.TryGetSettings(out _vignette);
        EventHandler.Instance.OnPlayerDamage += OnPlayerTakeDamage;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    //Change the vignette value depending on how much health left
    public void OnPlayerTakeDamage() => _vignette.intensity.value = (3f - (_healht.GetHealth() * (_healht.GetHealth() / 10000))) / 10;

    public void ResetVignette() => _vignette.intensity.value = 0;
}
