using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Settings
{
    public static float _globalVolume { get; private set; } = 0.5f;
    public static float _mouseSensitivity { get; private set; } = 5f;

    public static void UpdateGlobalVolume(float volume) {
        _globalVolume = volume;
        SoundManager.Instance.ChangeGlobalVolume(_globalVolume);
    }
    public static void UpdateMouseSensitivity(float sensitivity) {
        _mouseSensitivity = sensitivity;
    }
}
