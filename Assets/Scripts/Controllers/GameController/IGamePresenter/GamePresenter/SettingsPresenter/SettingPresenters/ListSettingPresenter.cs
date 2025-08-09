using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ListSettingPresenter<T> : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _text;
    private List<T> _values = new();

    internal Action<T> onValueChanged;

    internal void OutputValues(List<T> values)
    {
        _values = values;

        _slider.minValue = 0;
        _slider.maxValue = _values.Count - 1;
        _slider.wholeNumbers = true;
    }
    internal void OutputValue(T value)
    {
        _slider.SetValueWithoutNotify(_values.IndexOf(value));
    }

    internal void OutputFont(TMP_FontAsset font) =>
        _text.font = font;

    private void Awake() =>
        _slider.onValueChanged.AddListener(InputValue);
    private void OnDestroy() =>
        _slider.onValueChanged.RemoveListener(InputValue);

    private void InputValue(float value) =>
        onValueChanged?.Invoke(_values[(int)value]);
}
