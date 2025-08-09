using System;
using System.Collections.Generic;

public class ListSettingController<T> : IListSettingController<T>
{
    private List<T> _values;
    private T _value;

    public event Action<List<T>> onValuesChanged;
    public event Action<T> onValueChanged;

    public void SetValuesModel(List<T> values)
    {
        _values = values;
        onValuesChanged?.Invoke(_values);
    }
    public void SetDataModel(int value)
    {
        _value = _values[Math.Clamp(value, 0, _values.Count - 1)];
        onValueChanged?.Invoke(_value);
    }
    public void GetDataModel(ref int value) =>
        value = _values.IndexOf(_value);

    public void SetValueModel(T value)
    {
        _value = value;
        onValueChanged?.Invoke(_value);
    }

    public void Dispose() =>
        _values = null;
}
