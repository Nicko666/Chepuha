using System;

public class ReactiveProperty<T>
{
    private T _value;

    public T Value
    {
        get { return _value; }
        set 
        { 
            _value = value;
            onValueChanged?.Invoke(value);
        }
    }

    public Action<T> onValueChanged;


}
