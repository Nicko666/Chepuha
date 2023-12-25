using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    [SerializeField] Window[] window;

    public void OpenWindow(int index)
    {
        for (int i = 0; i < window.Length; i++)
        {
            window[i].Open = (i == index);
        }
    
    }


}
