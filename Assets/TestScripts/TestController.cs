using System;
using UnityEngine;

public class TestController : IDisposable
{
    private string _text;
    
    public Action<string> onAction;

    public TestController()
    {
        Debug.Log("TestController Created");
    }

    public void LoadData(string text)
    {
        onAction.Invoke(_text = text);
    }

    public void Dispose()
    {
        onAction.Invoke($"dispose {_text}");
        Debug.Log("TestController Disposed");
    }
}
