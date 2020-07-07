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
        _text.text = Mathf.Round(_slider.value) + percentage;
    }
    public void OnSliderValueChange() {
        float value = _slider.value / _slider.maxValue * 100;
        UpdateSetting(_optionType, _slider.value);
        UpdateText(value);
    }

    private void UpdateText(float value) {
        if (!_text) return;
        _text.text = Mathf.Round(value) + percentage;
    }
    private void UpdateSetting(OptionType type, float value) {
        if (type == OptionType.GlobalVolume) Settings.UpdateGlobalVolume(_slider.value - _slider.maxValue);
        else if (type == OptionType.MouseSensitivity) Settings.UpdateMouseSensitivity(value);
    }
}
