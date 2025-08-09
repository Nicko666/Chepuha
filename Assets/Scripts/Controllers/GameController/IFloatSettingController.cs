using System;
using UnityEngine;

public interface IFloatSettingController : IDisposable
{
    public event Action<Vector2> onValueLimitsChanged;
    public event Action<float> onValueChanged;

    public void SetBoundsModel(Vector2 valueLimitsModel);
    public void SetValueModel(float valueModel);
    public void GetValueModel(ref float valueModel);
}
