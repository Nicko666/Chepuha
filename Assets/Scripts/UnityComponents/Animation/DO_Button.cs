using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DO_Button : Selectable, IPointerClickHandler
{
    public UnityEvent onClick;
    public UnityEvent<bool> onInteractable;
    public UnityEvent onPointerDown;
    public UnityEvent onPointerUp;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (interactable)
            onClick?.Invoke();

    }

    public override bool IsInteractable()
    {
        return OnInteractable(base.IsInteractable());

    }

    public bool OnInteractable(bool value)
    {
        onInteractable?.Invoke(value);
        return value;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);

        if (interactable)
            onPointerDown?.Invoke();

    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);

        if (interactable)
            onPointerUp?.Invoke();
    
    }

    
}
