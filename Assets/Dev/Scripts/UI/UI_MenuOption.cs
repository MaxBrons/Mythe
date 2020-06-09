using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MenuOption : MonoBehaviour
{
    private enum OptionType { GlobalVolume, MouseSensitivity }

    [SerializeField] private OptionType _optionType;
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _text;
    private const string percentage = "%";

    private void Start() {
        if (!_text) return;
        _text.text = Mathf.Round(_slider.value * 100) + percentage;
    }
    public void OnSliderValueChange() {
        float value = Mathf.Clamp01(_slider.value);

        UpdateSetting(_optionType, value);
        UpdateText(value);
    }

    private void UpdateText(float value) {
        if (!_text) return;
        _text.text = Mathf.Round(value * 100) + percentage;
    }
    private void UpdateSetting(OptionType type, float value) {
        if (type == OptionType.GlobalVolume) Settings.UpdateGlobalVolume(value);
        else if (type == OptionType.MouseSensitivity) Settings.UpdateMouseSensitivity(value * 100);
    }
}
