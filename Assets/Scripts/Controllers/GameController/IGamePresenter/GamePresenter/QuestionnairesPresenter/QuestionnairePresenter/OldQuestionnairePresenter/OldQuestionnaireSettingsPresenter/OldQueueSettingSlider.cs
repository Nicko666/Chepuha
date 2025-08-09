using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OldQueueSettingSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string[] _description;
    private List<int> _values = new();

    internal Action<int> onValueChanged;

    internal void OutputValues(List<int> values)
    {
        _values = values;

        _slider.minValue = 0;
        _slider.maxValue = _values.Count - 1;
        _slider.wholeNumbers = true;
    }
    internal void OutputValue(int value)
    {
        _slider.SetValueWithoutNotify(_values.IndexOf(value));
        _text.text = _description[value];
    }

    internal void OutputFontModels(TMP_FontAsset font) =>
        _text.font = font;

    private void Awake() =>
        _slider.onValueChanged.AddListener(InputValue);
    private void OnDestroy() =>
        _slider.onValueChanged.RemoveListener(InputValue);

    private void InputValue(float value) =>
        onValueChanged?.Invoke(_values[(int)value]);
}
