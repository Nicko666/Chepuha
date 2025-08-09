using System.Collections.Generic;
using System;

public interface IListSettingController<T> : IDisposable
{
    public event Action<List<T>> onValuesChanged;
    public event Action<T> onValueChanged;
    public void SetValuesModel(List<T> values);
    public void SetValueModel(T value);
    public void SetDataModel(int value);
    public void GetDataModel(ref int value);
}
