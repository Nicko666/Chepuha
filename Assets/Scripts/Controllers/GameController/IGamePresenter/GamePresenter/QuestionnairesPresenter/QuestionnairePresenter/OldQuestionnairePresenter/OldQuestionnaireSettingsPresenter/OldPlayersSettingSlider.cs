using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OldPlayersSettingSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _0;
    [SerializeField] private string _1;
    [SerializeField] private string _234;
    private Vector2Int _valuesBoundsModel = Vector2Int.up;

    internal Action<int> onValueChanged;

    internal void OutputValuesModel(Vector2Int valuesBoundsModel)
    {
        _valuesBoundsModel = valuesBoundsModel;

        _slider.minValue = _valuesBoundsModel.x;
        _slider.maxValue = _valuesBoundsModel.y;
        _slider.wholeNumbers = true;
    }

    internal void OutputValueModel(int valueModel)
    {
        _slider.SetValueWithoutNotify(valueModel);

        string text = _0;
        if (valueModel < 10 || valueModel > 20)
        {
            if (valueModel % 10 == 1)
                text = _1;
            else if (valueModel % 10 > 1 && valueModel % 10 < 5)
                text = _234;
        }
        _text.text = $"{valueModel} {text}";
    }

    internal void OutputFontModel(TMP_FontAsset fontModel) =>
        _text.font = fontModel;

    private void Awake() =>
        _slider.onValueChanged.AddListener(InputValue);
    private void OnDestroy() =>
        _slider.onValueChanged.RemoveListener(InputValue);

    private void InputValue(float value) =>
        onValueChanged?.Invoke((int)value);


}
