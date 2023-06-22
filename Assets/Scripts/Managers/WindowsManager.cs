using UnityEngine;

public class WindowsManager : Singleton<WindowsManager>
{
    [SerializeField] Window[] _windows;
    [SerializeField] MessageWindow _message;

    private void Awake()
    {
        OpenWindow(0);

    }

    //public void OpenWindow(Window window)
    //{
    //    foreach (Window anuWindow in _windows)
    //    {
    //        if (anuWindow.gameObject.activeSelf)
    //        {
    //            anuWindow.Close();
    //        }
    //    }

    //    window.Open();

    //}

    public void OpenWindow(int num)
    {
        foreach (var window in _windows)
        {
            if (window.gameObject.activeSelf)
            {
                window.Close();
            }
        }

        _windows[num].Open();

    }

    public void ShowСonfirmationMessage(System.Action onYes, System.Action onNot, string message)
    {
        foreach (var window in _windows) window.Close();

        _message.CreateMessage(onYes, onNot, message);

    }


}
