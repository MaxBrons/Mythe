using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerUI : MonoBehaviour
{
    private PlayerHealth _healht;
    private void OnEnable() => EventHandler.Instance.OnPlayerDamage += OnPlayerTakeDamage;
    private void OnDisable() => EventHandler.Instance.OnPlayerDamage -= OnPlayerTakeDamage;
    private void Start() => _healht = GetComponent<PlayerHealth>();
    public void OnPlayerTakeDamage() {
        //Change the vignette value depending on how much health left
        PostProcessVolume volume = GameObject.FindGameObjectWithTag(Constants._postProcessingTag).GetComponent<PostProcessVolume>();
        Vignette vignette;
        volume.profile.TryGetSettings(out vignette);
        if (vignette != null) { vignette.intensity.value = (3f - (_healht.GetHealth() * (_healht.GetHealth() / 10000))) / 10; }
    }
}
