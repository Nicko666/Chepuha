using UnityEngine;

public abstract class Window : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;

    public bool Open
    {
        set
        {
            canvasGroup.interactable = value;
            OpenAnimation(value);
        }
    }

    protected abstract void OpenAnimation(bool value);


}
