using System;
using UnityEngine;

public class FloatSettingController : IFloatSettingController
{
    [SerializeField] private Vector2 _valueLimits;
    [SerializeField] private float _value;

    public event Action<Vector2> onValueLimitsChanged;
    public event Action<float> onValueChanged;

    public void SetBoundsModel(Vector2 valueLimitsModel)
    {
        _valueLimits = valueLimitsModel;
        onValueLimitsChanged.Invoke(_valueLimits);
    }

    public void SetValueModel(float valueModel)
    {
        _value = Math.Clamp(valueModel, _valueLimits.x, _valueLimits.y);
        onValueChanged.Invoke(_value);
    }
    public void GetValueModel(ref float valueModel) =>
        valueModel = _value;

    public void Dispose() { }
}