using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FloatSettingPresenter : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _text;
    
    internal Action<float> onValueChanged;

    internal void OutputBoundsModel(Vector2 limits)
    {
        _slider.minValue = limits.x;
        _slider.maxValue = limits.y;
    }
    internal void OutputValueModel(float value) =>
        _slider.SetValueWithoutNotify(value);

    internal void OutputFont(TMP_FontAsset font) =>
        _text.font = font;

    private void Awake() =>
        _slider.onValueChanged.AddListener(InputValue);
    private void OnDestroy() =>
        _slider.onValueChanged.RemoveListener(InputValue);

    private void InputValue(float value) =>
        onValueChanged?.Invoke(value);
}
